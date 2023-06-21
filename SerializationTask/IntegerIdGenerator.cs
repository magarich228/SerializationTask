using SerializationTask.Abstractions;

namespace SerializationTask
{
    public class IntegerIdGenerator : IIntegerIdGenerator
    {
        private int _id;

        public int CurrentId => _id;

        public IntegerIdGenerator()
        {
            _id = 0;
        }

        public int GetNextId() => ++_id;
    }
}
