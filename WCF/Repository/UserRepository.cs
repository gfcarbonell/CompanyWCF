using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF.Data;

namespace WCF.Repository
{
    public class UserRepository : IUserRepository
    {
        private string ConnectionStrings = ConfigurationManager.ConnectionStrings["Company"].ConnectionString;
        public bool Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionStrings))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_USER_DEL", con);
                    SqlParameter UserIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.VarChar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    UserIdParameter.Value = Id;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public ICollection<User> Get()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(this.ConnectionStrings))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_USER_QRY", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var user = new User();
                        user.UserId = Convert.ToInt32(rdr["UserId"]);
                        user.Username = rdr["Username"].ToString();
                        user.Password = rdr["Password"].ToString();
                        users.Add(user);
                    }
                    con.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return users;
        }

        public User GetById(int Id)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(this.ConnectionStrings))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_USER_SEL", con);
                    SqlParameter UserIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                    cmd.CommandType = CommandType.StoredProcedure;
                    UserIdParameter.Value = Id;

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        
                        if (dataReader.Read())
                        {
                            user.UserId = int.Parse(dataReader["UserId"].ToString());
                            user.Username = dataReader["Username"].ToString();
                            user.Password = dataReader["Password"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return user;
        }

        public User Save(User Entity)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionStrings))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_USER_INS", con);
                    SqlParameter UsernameParameter = cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                    SqlParameter PasswordParameter = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                    SqlParameter UserIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                    UserIdParameter.Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    UsernameParameter.Value = Entity.Username;
                    PasswordParameter.Value = Entity.Password;
                    cmd.ExecuteNonQuery();
                    Entity.UserId = int.Parse(UserIdParameter.Value.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Entity;
        }

        public User Update(User Entity)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionStrings))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_USER_UPD", con);
                    SqlParameter UserIdParameter = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                    SqlParameter UsernameParameter = cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                    SqlParameter PasswordParameter = cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    UserIdParameter.Value = Entity.UserId;
                    UsernameParameter.Value = Entity.Username;
                    PasswordParameter.Value = Entity.Password;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Entity;
        }
    }
}