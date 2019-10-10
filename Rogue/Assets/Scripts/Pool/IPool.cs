
public interface IPool<T>
{
    T GetInstance();

    void Reset(System.Action<T> resetAction);
}