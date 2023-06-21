using Faker;
using SerializationTask.Abstractions;
using SerializationTask.Models;

namespace SerializationTask
{
    public class ChildGenerator : IChildGenerator
    {
        private readonly IIntegerIdGenerator _idGenerator;

        public ChildGenerator(IIntegerIdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public Child Generate()
        {
            return new Child
            {
                Id = _idGenerator.GetNextId(),
                FirstName = Name.First(),
                LastName = Name.Last(),
                BirthDate = ((DateTimeOffset)Identification.DateOfBirth()).ToUnixTimeSeconds(),
                Gender = Faker.Enum.Random<Gender>()
            };
        }

        public IEnumerable<Child> GenerateNext(int count)
        {
            Child[] children = new Child[count];

            for (int i = 0; i < count; i++)
            {
                children[i] = Generate();
            }

            return children;
        }
    }
}
