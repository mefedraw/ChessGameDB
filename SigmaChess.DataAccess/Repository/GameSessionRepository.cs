
using SigmaChess.Core.Abstractions;
using SigmaChess.Core.Models;

namespace SigmaChess.DataAccess.Repository;

public class GameSessionRepository : IGameSessionRepository
{
    private readonly AppDbContext _context;

    public GameSessionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateGame(string inviteLink, string gameCreatorTgId)
    {
        var gameSession = new GameSession(inviteLink, gameCreatorTgId, DateTime.UtcNow);
        await _context.DbGameSession.AddAsync(gameSession);
        await _context.SaveChangesAsync();
    }

    public async Task AcceptGame(string inviteLink, string AcceptedByPlayerTgId)
    {
        var gameSession = _context.DbGameSession.Single(u => u.InviteLink == inviteLink);
        gameSession.Player2TgId = AcceptedByPlayerTgId;
        gameSession.StartedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }
    
}