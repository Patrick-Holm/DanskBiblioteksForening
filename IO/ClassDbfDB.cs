using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class ClassDbfDB : ClassDB
    {
        public ClassDbfDB()
        {
            SetCon("Server=10.205.44.39,49172;Database=DBF2019-2;User Id=AspIT;Password=Server2012;");
        }

        public ObservableCollection<ClassBog> GetAllBooksLike(string search)
        {
            DbReturnDataTable($"GetAllBooksLike '{search}'");
        }

        public ObservableCollection<ClassBog> GetAllBooksLentToUser(string id)
        {

        }

        public void UpdateTheLendingStatus(string id,bool status)
        {

        }

        public ClassUser GetUser(string userID, string password)
        {

        }
    }
}
