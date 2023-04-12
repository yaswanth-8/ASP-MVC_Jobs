// using Microsoft.Data.SqlClient;
// using System.Data;

// namespace WEB_APPLICATION
// {
//     public class DBManager
//     {
//         SqlConnection conn;
//         public DBManager(string dbName){
//         string connString = $"Data Source=DESKTOP-A1NJHOG;Initial Catalog={dbName};Integrated Security=True;Encrypt=False;";
//         conn = new SqlConnection(connString);
//         }

//     public List<T> runQuery<T>(string query,Func<SqlDataReader,T> mapper){
//         List<T> result = new List<T>();
//         using (SqlCommand command = new SqlCommand(query,conn))
//         using (SqlDataReader reader = command.ExecuteReader())
//         {
//             while (reader.Read())
//             {
//                 T item = mapper(reader);
//                 result.Add(item);
//             }
//         }
//         return result;
//         // Console.WriteLine("Inside run Query");
//         // if(conn.State == ConnectionState.Closed){conn.Open();}
//         //     SqlCommand cmd = new SqlCommand(query, conn);
//         //     SqlDataReader reader = cmd.ExecuteReader();
//         // // reader.Close();
//         // return reader;
//     }

//     }
// }


// // using (SqlConnection connection = new SqlConnection(connectionString))
// // {
// //     connection.Open();
// //     int input = int.Parse(Console.ReadLine());
// //     string query1 = "SELECT * FROM EmployeeInfo WHERE employee_id=1";
// //     using (SqlCommand command = new SqlCommand(query1, connection))
// //     { 

// //         command.CommandType = System.Data.CommandType.StoredProcedure;
// //         command.Parameters.Add("id",SqlDbType.Int).Value=input;

// //         Console.Write(command.ExecuteNonQuery());
// //         
// //     }
// // }