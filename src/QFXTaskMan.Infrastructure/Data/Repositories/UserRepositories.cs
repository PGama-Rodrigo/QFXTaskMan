using Microsoft.EntityFrameworkCore;
using QFXTaskMan.Core.Interfaces.Repositories;
using QFXTaskMan.Core.Models;
using QFXTaskMan.Infrastructure.Data.Context;

namespace QFXTaskMan.Infrastructure.Data.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id) ?? 
            throw new Exception("User not found");
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Where(u => !u.Deleted)  // Only non-deleted
            .ToListAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        // Deleted is false by default from BaseClass
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async System.Threading.Tasks.Task UpdateAsync(User user)
    {
        // Keep Deleted status as is
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            user.Deleted = true;  // Soft delete
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<User>> GetByOrganizationAsync(Guid organizationId)
    {
        return await _context.OrganizationsUsers
            .Where(ou => !ou.User.Deleted)  // Check both relations
            .Where(ou => ou.OrganizationId == organizationId)
            .Select(ou => ou.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetByTaskAsync(Guid taskId)
    {
        return await _context.ChoresUsers
            .Where(tu => !tu.User.Deleted)  // Check both relations
            .Where(tu => tu.ChoreId == taskId)
            .Select(tu => tu.User)
            .ToListAsync();
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }
}