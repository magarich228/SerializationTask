using Faker;
using Faker.Extensions;
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
                Phones = RandomNumber.Next(1, 3).Times<string>(p => Phone.Number()).ToArray(),
                CreditCardNumbers = RandomNumber.Next(1, 4).Times<string>(p => Faker.Finance.Isin()).ToArray(),
                Salary = RandomNumber.Next(20000, 400000),
                Children = _childGenerator.GenerateNext(RandomNumber.Next(0, 5)).ToArray()
            };
        }

        public IEnumerable<Person> GenerateNext(int count)
        {
            var persons = new Person[count];

            for (int i = 0; i < count; i++)
            {
                var person = Generate();
                person.SequenceId = i;

                persons[i] = person;
            }

            return persons;
        }
    }
}
