using UnityEngine;

public class RayHitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.activeInHierarchy) return;

        PlayerManager.Instance.ScoreIncrease.Invoke(1);
        collider.gameObject.SetActive(false);
    }
}