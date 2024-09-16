
using SigmaChess.Core.Models;
using SigmaChess.Core.Abstractions;

namespace SigmaChess.DataAccess.Repository;

public class UserAuthRepository : IUserAuthRepository
{
    private readonly AppDbContext _context;

    public UserAuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public string UserAvatar(string tgId)
    {
        var userAvatarUrl =  _context.DbUserAuth.Single(u => u.TgId == tgId);
        return userAvatarUrl.Avatar;
    }
    
    public async Task AuthUser(string tgId, string tgUsername, string avatar)
    {
        var tempUser = new UserAuth(tgId, tgUsername, DateOnly.FromDateTime(DateTime.UtcNow), avatar);
        await _context.DbUserAuth.AddAsync(tempUser);
        await _context.SaveChangesAsync();
    }
    
    public bool UserExists(string tgId)
    {
        var tempUser = _context.DbUserAuth.SingleOrDefault(u => u.TgId == tgId);
        return tempUser != null;
    }
}