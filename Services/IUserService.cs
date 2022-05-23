using Domain;


namespace Services
{
    public interface IUserService
    {
        
        List<User> GetUsers();
        void AddUser(User user);
        User GetUser(string id);

        void EditName(string id, string name);
        void EditPassword(string id, string password);
        public void EditProfile(string id, string url);
        public void Remove(string id);
    }
}