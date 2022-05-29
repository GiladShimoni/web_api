using Domain;


namespace Reposetory
{
    public class DB
    {
        public static List<User> Users = new List<User>()
        {
            new User{id = "mike",name = "Mike", password = "123", profiePic= "pic", server ="localhost:5005", Contacts = new List<Contact>()},
            new User{id = "pam",name = "Pam", password = "123", profiePic= "pic", server ="localhost:5005", Contacts = new List<Contact>()},
            new User{id = "kevin",name = "Kevin", password = "123", profiePic= "pic", server ="localhost:5005", Contacts = new List<Contact>()},
            new User{id = "kelly",name = "Kelly", password = "123", profiePic= "pic", server ="localhost:5005", Contacts = new List<Contact>()},

        };

        public static List<rMessages> Messages = new List<rMessages>();
      
    };
}