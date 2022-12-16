using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public  abstract class Spawner : MonoBehaviour
{


    [SerializeField] protected float _timeBetweenSpawn = 1f;
    [SerializeField] protected ObjectSpawnSystem _spawnSystem;


    // Use this for initialization
    protected virtual void Start()
    {
        _spawnSystem = GetComponent<ObjectSpawnSystem>();
        StartCoroutine(SpawnByTimeRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnByTimeRoutine());
    }

    protected abstract IEnumerator SpawnByTimeRoutine();

    /// <summary>
    /// Getting random position in perimeter outside of camera
    /// </summary>
    /// <remarks>
    /// X or Y will return as position point outside of camera view
    /// </remarks>
    /// <returns>random X and Y of Vector3 (Z = 0)</returns>
    protected Vector3 GetPositionRandomOutside()
    {
        float randomSide = Random.Range(0, 2) > 0 ? 1.1f : -0.1f;
        Vector3 position;
        if (Random.Range(0,2) > 0) //decide to spawn behind horizontal or vertical side of camera
        {
            //behind vertical
            position = new Vector3(randomSide, Random.value, 10f);
        }
        else
        {
            //behind horizontal
            position = new Vector3(Random.value, randomSide, 10f);
        }

        var cameraPos = Camera.main.ViewportToWorldPoint(position);
        return new Vector3(cameraPos.x, cameraPos.y);
    }

    protected void SetObjectData(MonoBehaviour obj, Vector3 position, Quaternion rotation, MoveData moveData)
    {
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.GetComponent<MoveData>().SetMoveData(moveData);
    }

    protected MonoBehaviour GetSpawnObject(ObjectSpawnSystem spawnSystem, Vector3 position, Quaternion rotation,
        MoveData moveData)
    {
        var obj = GetSpawnObject(spawnSystem);
        SetObjectData(obj, position, rotation, moveData);
        return obj;
    }

    protected MonoBehaviour GetSpawnObject(ObjectSpawnSystem spawnSystem)
    {
        var obj = spawnSystem.GetEntity();

        return obj;
    }
}