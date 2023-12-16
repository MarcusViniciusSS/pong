using UnityEngine;
using UnityEditor;
using Runtime.Systems.GeneralManager.Scripts;

namespace Runtime.Systems.Menu.Scripts
{
    public class MenuUIController : MonoBehaviour
    {
        public void StartGame(int numberScene) => SceneController.Instance.NextLevel(numberScene);

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
