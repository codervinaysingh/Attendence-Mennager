using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Attendence.Models.Data
{
    public class RegisterModel : IStudentRegister
    {
        private readonly IDbConnection _connection;

        public RegisterModel(IDbConnection connection)
        {
            this._connection = connection;
        }
        public string AddStudent(Register register)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@StudentName",register.StudentName),
                    new SqlParameter("@MobileNo",register.ContactNumber)
                };
                var dt = _connection.ExcuteByProcedure("sp_AddStudent", param);
                return JsonConvert.SerializeObject(dt).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Attendence(Register register)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@id",register.Id)
                };
                var dt = _connection.ExcuteByProcedure("sp_Attendence", param);
                return JsonConvert.SerializeObject(dt).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetReport(string date)
        {
            try
            {
                SqlParameter[] param =
                                {

                    new SqlParameter("@Date",date.ToString())
                };
                var dt = _connection.ExcuteByProcedure("sp_ReportStudent", param);
                return JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string SearchStudent(Register register)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MobileNo",register.ContactNumber)
                };
                var dt = _connection.ExcuteByProcedure("sp_SearchStudent", param);
                return JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
