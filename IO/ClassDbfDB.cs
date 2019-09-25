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
        /// <summary>
        /// Set the connection string to connect to a DB of our choise
        /// </summary>
        public ClassDbfDB()
        {
            SetCon("Server=10.205.44.39,49172;Database=DBF2019-2;User Id=AspIT;Password=Server2012;");
        }

        /// <summary>
        /// Retrive Books from database by calling stored procedur "GetAllBooksLike"
        /// </summary>
        /// <param name="search">User Search</param>
        /// <returns>ObservableCollection<ClassBook> containg the value of search in the title
        /// If empty returns all books from DB</returns>
        public ObservableCollection<ClassBog> GetAllBooksLike(string search)
        {
            DbReturnDataTable($"GetAllBooksLike '{search}'");
        }

        /// <summary>
        /// Retrive all books lent to current user by calling stored procedur "GetAllBooksLentToUser"
        /// </summary>
        /// <param name="id">Current user id</param>
        /// <returns>ObservableCollection<ClassBook> with all books lent to current user</returns>
        public ObservableCollection<ClassBog> GetAllBooksLentToUser(string id)
        {
            DbReturnDataTable($"GetAllBooksLentToUser {id}");
        }

        /// <summary>
        /// Update the lenting status of a book
        /// </summary>
        /// <param name="id">if of book</param>
        /// <param name="status">new lending status to selected book</param>
        public void UpdateTheLendingStatus(string id,string status)
        {
            ExecuteNonQuery($"UpdateLendingStatus {id}, {status}");
        }

        /// <summary>
        /// finds the user trying to log in
        /// </summary>
        /// <param name="userID">username of user</param>
        /// <param name="password">password fo user</param>
        /// <returns>id of user if logIn infomation is right</returns>
        public ClassUser GetUser(string userID, string password)
        {
            DbReturnDataTable($"GetUser '{userID}','{password}'");
        }
    }
}
