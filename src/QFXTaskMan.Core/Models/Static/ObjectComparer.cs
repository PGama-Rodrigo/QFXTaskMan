namespace QFXTaskMan.Core.Models.Static;

public static class ObjectComparer
{
    public static string[] CompareAndExport<T>(T? before, T? after, string prefix = "") where T : class
    {
        var diffs = CompareObjects(before, after, prefix);
        return ExportDifferencesToJson(diffs);
    }

    private static Dictionary<string, (object? Before, object? After)> CompareObjects<T>(T? before, T? after, string prefix = "") 
        where T : class
    {
        var differences = new Dictionary<string, (object? Before, object? After)>();
        
        if (before == null && after == null)
            throw new ArgumentNullException("Objects cannot be null");
            
        var properties = typeof(T).GetProperties();
        
        foreach (var prop in properties)
        {
            var beforeValue = prop.GetValue(before);
            var afterValue = prop.GetValue(after);
            
            // Handle collections (like List<SaleItem>)
            if (typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
            {
                var beforeList = beforeValue != null ? ((IEnumerable<object>)beforeValue).ToList() : new List<object>();
                var afterList = afterValue != null ? ((IEnumerable<object>)afterValue).ToList() : new List<object>();

                // Compare collections
                CompareCollections(beforeList, afterList, prop.Name, differences);
                continue;
            }
            
            // Handle nested objects
            if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
            {
                if (beforeValue != null || afterValue != null)
                {
                    var nestedDifferences = CompareObjects(
                        beforeValue, 
                        afterValue, 
                        $"{prefix}{prop.Name}.");
                        
                    foreach (var diff in nestedDifferences)
                    {
                        differences.Add(diff.Key, diff.Value);
                    }
                }
                continue;
            }

            // Compare simple properties
            if (!Equals(beforeValue, afterValue))
            {
                differences.Add($"{prefix}{prop.Name}", (beforeValue, afterValue));
            }
        }
        
        return differences;
    }

    private static void CompareCollections(List<object> beforeList, List<object> afterList, string propertyName, Dictionary<string, (object? Before, object? After)> differences)
    {
        // Find items that were added
        var addedItems = afterList.Where(a => !beforeList.Any(b => 
            GetIdentifierValue(b).Equals(GetIdentifierValue(a)))).ToList();

        // Find items that were removed
        var removedItems = beforeList.Where(b => !afterList.Any(a => 
            GetIdentifierValue(a).Equals(GetIdentifierValue(b)))).ToList();

        // Find modified items
        var modifiedItems = beforeList
            .Join(afterList,
                b => GetIdentifierValue(b),
                a => GetIdentifierValue(a),
                (b, a) => new { Before = b, After = a })
            .Where(pair => !pair.Before.Equals(pair.After))
            .ToList();

        // Add differences for collections
        if (addedItems.Count != 0)
            differences.Add($"{propertyName}.Added", (null, addedItems));
            
        if (removedItems.Count != 0)
            differences.Add($"{propertyName}.Removed", (removedItems, null));
            
        if (modifiedItems.Count != 0)
            differences.Add($"{propertyName}.Modified", 
                (modifiedItems.Select(m => m.Before).ToList(), 
                 modifiedItems.Select(m => m.After).ToList()));
    }

    private static object GetIdentifierValue(object obj)
    {
        // Try to get Id property (you might want to make this more flexible)
        var idProperty = obj.GetType().GetProperty("Id");
        return idProperty?.GetValue(obj) ?? obj;
    }

    private static string[] ExportDifferencesToJson(Dictionary<string, (object? Before, object? After)> differences)
    {
        string resultBefore = "{";
        string resultAfter = "{";

        foreach (var diff in differences)
        {
            resultBefore += $"\"{diff.Key}\": \"{diff.Value.Before}\"";
            resultAfter += $"\"{diff.Key}\": \"{diff.Value.After}\"";

            if (!differences.Last().Equals(diff))
            {
                resultBefore += ",";
                resultAfter += ",";
            }
        }

        resultBefore += "}";
        resultAfter += "}";

        return [resultBefore, resultAfter];
    }
}