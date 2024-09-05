using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FastFurios_Game.Controllers
{
    public class SceneController : MonoBehaviour
    {
        public int NEXT_SCENE_NUMBER = 2;

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
}
