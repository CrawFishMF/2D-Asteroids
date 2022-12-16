using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private bool _isHorizontal;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var position = collider.transform.parent.position;
        var newPosition = position;
        if (_isHorizontal)
        {
            newPosition.y *= -0.97f;
        }
        else
        {
            newPosition.x *= -0.97f;
        }

        collider.transform.parent.position = newPosition;
    }
}