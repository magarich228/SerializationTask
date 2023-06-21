namespace SerializationTask.Models
{
    public class Person
    {
        public Int32 Id { get; set; }
        public Guid TransportId { get; set; }
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
        public Int32 SequenceId { get; set; }
        public String[] CreditCardNumbers { get; set; } = null!;
        public Int32 Age { get; set; }
        public String[] Phones { get; set; } = null!;
        public Int64 BirthDate { get; set; }
        public Double Salary { get; set; }
        public Boolean IsMarred { get; set; }
        public Gender Gender { get; set; }
        public Child[] Children { get; set; } = null!;
    }
}
