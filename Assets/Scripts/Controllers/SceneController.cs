using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public const int NEXT_SCENE_NUMBER = 2;

    private AsyncOperation asyncOperation;

    public void LoadNextSceneAsync()
    {
        asyncOperation = SceneManager.LoadSceneAsync(NEXT_SCENE_NUMBER, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        StartCoroutine(WaitForSceneToLoad());
    }

    private IEnumerator WaitForSceneToLoad()
    {
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        asyncOperation.allowSceneActivation = true;
    }
}
