namespace SerializationTask.Models
{
    public class Child
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
        public Int64 BirthDate { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
