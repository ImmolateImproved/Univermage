using System.Collections.Generic;
using System;

public class ListPool<T> : IPool<T>
{
    List<T> objectPool = new List<T>();

    Func<T> Produce;
    Func<T, bool> UseTest;

    public ListPool(Func<T> _produce, Func<T, bool> _useTest)
    {
        Produce = _produce;
        UseTest = _useTest;
    }

    public T GetInstance()
    {
        T ob = objectPool.Find((x) => UseTest(x));

        if (ob == null)
        {
            ob = Produce();
            objectPool.Add(ob);
        }

        return ob;
    }

    public void Reset(Action<T> resetAction)
    {
        foreach (var item in objectPool)
        {
            resetAction(item);
        }
    }
}