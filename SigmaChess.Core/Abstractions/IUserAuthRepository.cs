namespace SigmaChess.Core.Abstractions;

public interface IUserAuthRepository
{
    Task AuthUser(string tgId, string tgUsername, string avatar);

    string UserAvatar(string tgId);

    bool UserExists(string tgId);
}