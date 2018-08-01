using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

//

namespace ContactLibrary
{
    public static class SQLConnection
    {
        //directory file
        private static string directory = "Documents\\SerializationOverview.txt";
       
        //coneection string
        private static string connectionString = "Server = tcp:rev-cuny-server-cameron.database.windows.net,1433;Initial Catalog = PhoneProjectDB; Persist Security Info=False;User ID = cchen1; Password=Password123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
        //SQL commands
        private static string loadSQL = "SELECT * FROM JSONValues";
        private static string delSQL = "DELETE FROM JSONValues";
        private static string saveSQLa = "INSERT INTO JSONValues (JString) VALUES(Convert(VARBINARY(MAX), '";
        private static string saveSQLb = "'));";
        //ID for the each person
        public static short iD = (short)DateTime.Now.Ticks; 

        //Reader & Writer methods for directory file
        public static void WriteToFile(string info) { System.IO.File.WriteAllText(directory, info); }
        public static string ReadFromFile() { return System.IO.File.ReadAllText(directory); }

        public static string ReadFromSQL_DB()
        {
            //connection string input
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SQL command
                SqlCommand command = new SqlCommand(loadSQL, connection);
                try
                {
                    //open connection
                    connection.Open();
                    //convert to byte code
                    byte[] bytey = (byte[])command.ExecuteScalar();
                    
                    return Encoding.ASCII.GetString(bytey);
                }
                catch (Exception e) { Console.WriteLine($"Error {e.ToString()}"); }
            }
            return null;
        }

        public static void WriteToSQL_DB(string jsonString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string saveSQL = saveSQLa + jsonString + saveSQLb;
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(delSQL, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    adapter.InsertCommand = new SqlCommand(saveSQL, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception e) { Console.WriteLine($"Error {e.ToString()}"); }

            }
        }
    }


    public class SerializerJSON
    {
        public static object OutsideConnect { get; private set; }

        //Serialize to json string to SQL
        public static string JsonSerializer<T>(T t)
        {
            string jsonstring = new JavaScriptSerializer().Serialize(t);
            
            SQLConnection.WriteToSQL_DB(jsonstring);
            return jsonstring;
        }

        //Deserialize Json string from SQL
        public static T JsonDeserialize<T>()
        {
            
            string jsonstring = SQLConnection.ReadFromSQL_DB();
            JavaScriptSerializer deserializer = new JavaScriptSerializer();
            return deserializer.Deserialize<T>(jsonstring);
        }

    }
}
