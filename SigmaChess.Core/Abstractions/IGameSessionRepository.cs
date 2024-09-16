namespace SigmaChess.Core.Abstractions;
using SigmaChess.Core.Models;

public interface IGameSessionRepository
{
     Task CreateGame(string inviteLink, string gameCreatorTgId);
     Task AcceptGame(string inviteLink, string acceptedByPlayerTgId);
}