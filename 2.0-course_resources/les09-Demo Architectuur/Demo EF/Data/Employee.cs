namespace Demo_EF.Data
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; } //FK entity Department
        public Department Department { get; set; }
    }
}
