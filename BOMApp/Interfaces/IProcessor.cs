namespace BOMApp
{
    public interface IProcessor<T>
    {
        string Process();

        string BOMBuilder(T input);
    }
} 
