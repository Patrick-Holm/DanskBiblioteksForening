using System.Data;
using System.Data.SqlClient;

namespace IO
{
    public class ClassDB
    {
        private string connectionString;
        private SqlConnection con;
        private SqlCommand command;

        /// <summary>
        /// Sets the connctionString with some defualt settings
        /// Then set the SqlConnection to what the string says.
        /// 
        /// Be carefull then using this construkter
        /// since the settings may be wong.
        /// </summary>
        public ClassDB()
        {

        }

        /// <summary>
        /// set the SqlConnection based on the recived string.
        /// Save the connctionstring and the SQL-Connction in the respektive fields
        /// </summary>
        /// <param name="yourConString">A string with the connection settings</param>
        public ClassDB(string yourConString)
        {
            connectionString = yourConString;
            con = new SqlConnection(connectionString);
        }

        /// <summary>         
        /// set the SqlConnection based on the recived string.
        /// Save the connctionstring and the SQL-Connction in the respektive fields
        /// </summary>
        /// <param name="yourConString">A string with the connection settings</param>
        protected void SetCon(string yourConString)
        {
            connectionString = yourConString;
            con = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Open the Connction to the DB with the SQL-Connction
        /// </summary>
        private void OpenDB()
        {
            // Catches and trows any Exception that might happen
            try
            {
                //Checks IF the SQL-Connction is not null and the state of the Connection is closed
                if (this.con != null && con.State == ConnectionState.Closed)
                {
                    //Open the Connection based on the SQL-Connction
                    con.Open();
                }
                else
                {
                    //Calls a method that closes the Connction
                    CloseDB();

                    //Make a recursive call
                    OpenDB();
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
        }

        /// <summary>
        /// Closes the connection to the DB
        /// If any ExCeption. throw it
        /// </summary>
        private void CloseDB()
        {
            try
            {
                con.Close();
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
        }

        /// <summary> 
        /// This method takes an SQL-query as a parameter.
        /// The res variable holds an integer value that represents the outcome of ExecuteNonQuery.
        /// Field command is set to a new SqlCommand where the SQL-query and connection is defined.
        /// A connection to the database is opened and the SQL-command is executed by calling the
        /// command.ExecuteNonQuery() method. The outcome of the operation is stored in res (1 for succesful,
        /// and 0 for unsuccesful).         
        /// If anything goes wrong, an exception is thrown. 
        /// In Finally the CloseDB() will be called to close the
        /// connection, independed of an exception is thrown or not.
        /// Lastly, res is returned to the method caller.
        /// </summary>
        /// <param name="sqlQuery">String with the SQL-query</param>
        /// <returns>An integer representing the outcome of the execution</returns> 
        protected int ExecuteNonQuery(string sqlQuery)
        {
            int res = 0;
            command = new SqlCommand(sqlQuery, con);
            try
            {
                OpenDB();
                res = command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
            finally
            {
                CloseDB();
            }
            return res;
        }

        /// <summary>
        /// Returns a DataTable with the values recived from the database
        /// </summary>
        /// <param name="sqlQuery">String with the SQL-query</param>
        /// <returns>A DataTable with values depenting on sqlQuery</returns>
        protected DataTable DbReturnDataTable(string sqlQuery)
        {
            // Generete a new instance of DataTable
            DataTable dtRes = new DataTable();

            // trys to catch any Exception that may appear
            try
            {
                //Calls a method that open the SqlConnection to the DataBase
                OpenDB();

                // Generete an SQL-Command based on sqlQuery
                // then fill a var with values from the DataTable with the SQL-DataAdapter
                using (command = new SqlCommand(sqlQuery, con))
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dtRes);
                }
                //the garbage-Collecter stops the use of command and adapter
            }
            catch (SqlException sqlEx)
            {

                throw sqlEx;
            }
            finally
            {
                //Calls a method that colses the connection to the DataBase
                CloseDB();
            }
            return dtRes;
        }
    }
}
