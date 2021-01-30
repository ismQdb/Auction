using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class UserCollection  : ObservableCollection<User> {
        public static List<User> GetAllUsers() {
            List<User> users = new List<User>();
            User user;

            using(SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT UserID, UserName, UserPassword, IsAdmin FROM dbo.[User];", connection);

                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        user = new User((int)reader["UserID"], (string)reader["UserName"], (string)reader["UserPassword"], (bool)reader["IsAdmin"]);
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public static int CheckUserStatus(User user) {
            Random random = new Random();
            User userFromDatabase;
            int userID;

            using(SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                connection.Open();

                #region Get User ID

                SqlCommand getIdCommand = new SqlCommand("SELECT UserID FROM dbo.[User] WHERE UserName = @UserName AND UserPassword = @UserPassword", connection);

                SqlParameter userNameParameter = new SqlParameter("@UserName", System.Data.SqlDbType.NVarChar);
                userNameParameter.Value = user.UserName;

                SqlParameter userPasswordParameter = new SqlParameter("@UserPassword", System.Data.SqlDbType.NVarChar);
                userPasswordParameter.Value = user.UserPassword;

                getIdCommand.Parameters.Add(userNameParameter);
                getIdCommand.Parameters.Add(userPasswordParameter);

                using(SqlDataReader reader = getIdCommand.ExecuteReader()) {
                    reader.Read();
                    userID = (int)reader["UserID"];
                }
                #endregion

                #region Get User
                SqlCommand command = new SqlCommand("SELECT * from dbo.[User] WHERE UserID=@id", connection);

                SqlParameter idParameter = new SqlParameter("@id", System.Data.SqlDbType.Int);
                idParameter.Value = userID;

                command.Parameters.Add(idParameter);

                using(SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read() == false)
                        return 2;
                    else
                        userFromDatabase = new User((int)reader["UserID"], (string)reader["UserName"], (string)reader["UserPassword"], (bool)reader["IsAdmin"]);
                }
                #endregion

                if (userFromDatabase.IsAdmin == true)
                    return 0;
                else 
                    return 1;
            }
        }
    }
}
