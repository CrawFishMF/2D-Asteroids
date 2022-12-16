using UnityEngine;

public class ObjectSpawnSystem : MonoBehaviour
{
    public MonoBehaviour Prefab;
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private int _poolCount = 5;
    [SerializeField] private bool _autoExpand = true;
    private ObjectPool<MonoBehaviour> _pool;

    private void Start()
    {
        _pool = new ObjectPool<MonoBehaviour>(Prefab, _poolCount, _poolContainer);
        _pool.AutoExpand = _autoExpand;
    }

    public MonoBehaviour GetEntity()
    {
        return _pool.GetFreeElement();
    }
}

