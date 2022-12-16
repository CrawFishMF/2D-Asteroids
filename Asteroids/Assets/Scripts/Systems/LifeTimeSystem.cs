using System.Collections;
using UnityEngine;

public class LifeTimeSystem : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;

    private void OnEnable()
    {
        StartCoroutine(LifeRoutine());
    }
    private void OnDisable()
    {
        StopCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);

        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}