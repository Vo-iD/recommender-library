using RL.Entity.Own;

namespace RL.OwnData.Contract.Infrastructure
{
    public interface IUserRepository
    {
        void Update(User user);
        User GetUser(string id);
        void Save();
    }
}
