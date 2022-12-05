using System.Data;
using System.Data.SqlClient;

namespace Attendence.Models.Data
{
    public class DbConnection:IDbConnection
    {
        protected readonly IConfiguration _config;
        private readonly string connectionString;
        public DbConnection(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("dbConnection");
        }
        public void Excute(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn =new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    cmd.ExecuteNonQuery();  
                    conn.Close();
                       
                }
                catch (Exception ex)
                {

                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally{
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable ExcuteByProcedure(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn =new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                try
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                    return dt;

                }
                catch (Exception ex)
                {

                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally{
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
    }
}
