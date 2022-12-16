using UnityEngine;

public class PlayerCrashTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerDeath();
    }
    private void PlayerDeath()
    {
        PlayerRedColoring();
        UIManager.Instance.UICallback.PlayerWasted();
    }
    private void PlayerRedColoring()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

}
