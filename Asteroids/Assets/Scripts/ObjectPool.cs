using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform PoolContainer { get; }

    private List<T> _pool;
    public ObjectPool(T prefab, int count)
    {
        Prefab = prefab;
        PoolContainer = null;

        CreatePool(count);
    }

    public ObjectPool(T prefab, int count, Transform poolContainer)
    {
        Prefab = prefab;
        PoolContainer = poolContainer;

        CreatePool(count);
    }
    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
            this.CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prefab, PoolContainer);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }
    /// <summary>
    /// Finding any disabled element in pool and enabling it
    /// </summary>
    public bool HasFreeElement(out T element)
    {
        foreach (var behaviour in _pool)
        {
            if (!behaviour.gameObject.activeInHierarchy)
            {
                behaviour.gameObject.SetActive(true);
                element = behaviour;
                return true;
            }
        }
        element = null;
        return false;
    }
    /// <summary>
    /// Getting disabled element from pool and enable it, also expanding pool
    /// </summary>
    /// <remarks>
    /// if pool isn't AutoExpanding returning null
    /// </remarks>
    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }

        if (AutoExpand)
        {
            return CreateObject(true);
        }

        return null;
    }
}
