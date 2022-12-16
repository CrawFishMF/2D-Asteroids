using UnityEngine;

public class BulletHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //evade situation when two bullets/objects hit one object/bullet simultaneously
        if (!collider.gameObject.activeInHierarchy) return;
        if (!gameObject.activeInHierarchy) return;

        if (collider.gameObject.layer == 11) //11 layer - asteroids
        {
            if (collider.gameObject.TryGetComponent<AsteroidBlast>(out var blast))
                blast.TryBlastIt();
        }

        PlayerManager.Instance.ScoreIncrease.Invoke(1);
        collider.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}