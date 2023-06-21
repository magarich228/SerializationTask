namespace SerializationTask.Abstractions
{
    public interface IIntegerIdGenerator
    {
        int CurrentId { get; }
        int GetNextId();
    }
}
