namespace SerializationTask.Abstractions
{
    public interface IGenerator<T>
    {
        public T Generate();
        public IEnumerable<T> GenerateNext(int count);
    }
}
