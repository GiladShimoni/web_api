using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRatingServices
    {
        public List<Ratings> GetAll();

        public Ratings Get(int id);

        public void Edit(int id, string username, int rating, string comment);

        public void Create(string username, int rating, string comment);

        public void Delete(int id);
    }
}
