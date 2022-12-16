using System.Collections;
using UnityEngine;

public class AsteroidSpawner : Spawner
{
    [SerializeField] private float _minSpeed = 0.1f;
    [SerializeField] private float _maxSpeed = 2f;

    public Vector3 BaseAsteroidScale = new (0.7f, 0.7f, 0.7f);
    public MoveData BaseMoveData;
    public Vector3 FragmentScale  = new (0.2f, 0.2f, 0.2f);
    public float FragmentMoveSpeed  = 3f;
    public int FragmentCount = 4;

    protected override IEnumerator SpawnByTimeRoutine()
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSecondsRealtime(_timeBetweenSpawn);

            var asteroid = GetNewAsteroid();

            var spawnPosition = GetPositionRandomOutside();
            var spawnRotation = Quaternion.Euler(new Vector3(0,0,Random.Range(-180,180)));

            if(asteroid.TryGetComponent<MoveData>(out var newMoveData))
                newMoveData.MoveSpeed = Random.Range(_minSpeed, _maxSpeed);


            SetObjectData(asteroid, spawnPosition, spawnRotation, newMoveData);
        }
    }

    public MonoBehaviour GetNewAsteroid()
    {
        var asteroid =  GetSpawnObject(_spawnSystem);
        if (asteroid.TryGetComponent<AsteroidBlast>(out var asteroidBlast))
            asteroidBlast.AsteroidSpawner = this;
        return asteroid;
    }
}