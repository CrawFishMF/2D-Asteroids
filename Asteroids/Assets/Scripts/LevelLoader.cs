using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    private IEnumerator LoadAsync(int sceneIndex)
    {
        var operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        yield return null;
    }
}
