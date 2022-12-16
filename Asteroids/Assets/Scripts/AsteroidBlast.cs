using UnityEngine;

public class AsteroidBlast : MonoBehaviour
{
    public AsteroidSpawner AsteroidSpawner { get; set; }
    /// <summary>
    /// try spawning fragments in place of main asteroid
    /// </summary>
    public void TryBlastIt()
    {
        if (transform.localScale != AsteroidSpawner.BaseAsteroidScale)
        {
            transform.localScale = AsteroidSpawner.BaseAsteroidScale;
            return;
        }

        var moveData = AsteroidSpawner.BaseMoveData;
        moveData.MoveSpeed = AsteroidSpawner.FragmentMoveSpeed;
        for (int i = 0; i < AsteroidSpawner.FragmentCount; i++)
        {
            SpawnFragment(AsteroidSpawner, moveData, AsteroidSpawner.FragmentScale);
        }
    }

    private void SpawnFragment(AsteroidSpawner asteroidSpawner, MoveData moveData, Vector3 scale)
    {
        var fragment = asteroidSpawner.GetNewAsteroid();
        fragment.GetComponent<MoveData>().SetMoveData(moveData);
        fragment.transform.localScale = scale;
        fragment.transform.position = transform.position;
        fragment.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180)));
    }
}
