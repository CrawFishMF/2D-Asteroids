using System.Collections;
using UnityEngine;

public class ChaserSpawner : Spawner
{
    [SerializeField] private float _minSpeed = 0.5f;
    [SerializeField] private float _maxSpeed = 2f;
    [SerializeField] private float _minRotateSpeed = 0.1f;
    [SerializeField] private float _maxRotateSpeed = 0.5f;

    protected override IEnumerator SpawnByTimeRoutine()
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSeconds(_timeBetweenSpawn);

            var entity = GetSpawnObject(_spawnSystem);

            var spawnPosition = GetPositionRandomOutside();
            var newMoveData = entity.GetComponent<MoveData>();
            newMoveData.RotationSpeed = Random.Range(_minRotateSpeed, _maxRotateSpeed);
            newMoveData.MoveSpeed = Random.Range(_minSpeed, _maxSpeed);

            SetObjectData(entity, spawnPosition, Quaternion.identity, newMoveData);
        }
    }

}