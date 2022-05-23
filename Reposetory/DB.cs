using Domain;


namespace Reposetory
{
    public class DB
    {
        public static List<User> Users = new List<User>()
        {
            new User{id = "mike",name = "prisonMike", password = "123", profiePic= "pic", server ="localhost", Contacts = new List<Contact>()},
            new User{id = "pam",name = "pam", password = "iloveroy", profiePic= "pic", server ="localhost", Contacts = new List<Contact>()},
            new User{id = "keivn",name = "cockies", password = "yumyum", profiePic= "pic", server ="localhost", Contacts = new List<Contact>()},
            new User{id = "kelly",name = "kelly", password = "omgRyan", profiePic= "pic", server ="localhost", Contacts = new List<Contact>()},

        };

      
    };
}