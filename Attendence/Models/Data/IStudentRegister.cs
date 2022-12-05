namespace Attendence.Models.Data
{
    public interface IStudentRegister
    {
        public string AddStudent(Register register);
        public string SearchStudent(Register register);
        public string Attendence(Register register);
        public string GetReport(string date);

    }
}
