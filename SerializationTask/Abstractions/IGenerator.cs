namespace SerializationTask.Abstractions
{
    public interface IGenerator<T>
    {
        T Generate();
        IEnumerable<T> GenerateNext(int count);
    }
}
