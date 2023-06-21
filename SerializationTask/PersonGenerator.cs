using Faker;
using SerializationTask.Abstractions;
using SerializationTask.Models;

namespace SerializationTask
{
    public class PersonGenerator : IPersonGenerator
    {
        private readonly IIntegerIdGenerator _idGenerator;
        private readonly IChildGenerator _childGenerator;

        public PersonGenerator(
            IIntegerIdGenerator idGenerator, 
            IChildGenerator childGenerator)
        {
            _idGenerator = idGenerator;
            _childGenerator = childGenerator;

        }

        public Person Generate()
        {
            return new Person
            {
                Id = _idGenerator.GetNextId(),
                FirstName = Name.First(),
                LastName = Name.Last(),
                Age = RandomNumber.Next(18, 100),
                BirthDate = ((DateTimeOffset)Identification.DateOfBirth()).ToUnixTimeSeconds(),
                TransportId = Guid.NewGuid(),
                Gender = Faker.Enum.Random<Gender>(),
                IsMarred = Faker.Boolean.Random(),
                Phones = new[] { Phone.Number() },
                SequenceId = 0,
                CreditCardNumbers = new[] { Faker.Finance.Isin() },
                Salary = RandomNumber.Next(20000, 400000),
                Children = new[]
                {
                    _childGenerator.Generate()
                }
            };
        }

        public IEnumerable<Person> GenerateNext(int count)
        {
            Person[] persons = new Person[count];

            for (int i = 0; i < count; i++)
            {
                persons[i] = Generate();
            }

            return persons;
        }
    }
}
