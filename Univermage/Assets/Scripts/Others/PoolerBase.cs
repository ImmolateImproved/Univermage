using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolerBase<T> where T : Component
{
    private T _prefab;
    private ObjectPool<T> _pool;

    public ObjectPool<T> Pool
    {
        get
        {
            if (_pool == null) throw new InvalidOperationException("You need to call InitPool before using it.");
            return _pool;
        }
        private set => _pool = value;
    }

    public void InitPool(T prefab, int initial = 10, int max = 20, bool collectionChecks = false)
    {
        _prefab = prefab;
        Pool = new ObjectPool<T>(
            CreateSetup,
            GetSetup,
            ReleaseSetup,
            DestroySetup,
            collectionChecks,
            initial,
            max);
    }

    #region Overrides
    protected virtual T CreateSetup() => GameObject.Instantiate(_prefab);
    protected virtual void GetSetup(T obj) => obj.gameObject.SetActive(true);
    protected virtual void ReleaseSetup(T obj) => obj.gameObject.SetActive(false);
    protected virtual void DestroySetup(T obj) => GameObject.Destroy(obj);
    #endregion

    #region Getters
    public T Get() => Pool.Get();
    public void Release(T obj) => Pool.Release(obj);
    #endregion
}