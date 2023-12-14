using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Runtime.Systems.Menu.Scripts
{
    public class MenuUIController : MonoBehaviour
    {
        public void GoSceneAsync(string sceneName) => SceneManager.LoadSceneAsync(sceneName);

        public void GoSceneNoAsync(string sceneName) => SceneManager.LoadScene(sceneName);

        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
