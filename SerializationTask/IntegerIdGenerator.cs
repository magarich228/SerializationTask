namespace SerializationTask
{
    public class IntegerIdGenerator
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
