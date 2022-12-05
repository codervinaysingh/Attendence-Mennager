using System.Data;
using System.Data.SqlClient;

namespace Attendence.Models.Data
{
    public interface IDbConnection
    {
        public void Excute(string CommandName, SqlParameter[] param);
        public DataTable ExcuteByProcedure(string CommandName, SqlParameter[] param);
    }
}
