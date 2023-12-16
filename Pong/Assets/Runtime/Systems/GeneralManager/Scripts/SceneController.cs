using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Systems.GeneralManager.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController Instance { get; private set; }
        [SerializeField] private GameObject transitionGameObject;
        [SerializeField] private Animator transitionAnimator;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        public void NextLevel(int indexScene) => StartCoroutine(LoadLevel(indexScene));

        IEnumerator LoadLevel(int indexScene)
        {
            transitionGameObject.SetActive(true);
            transitionAnimator.SetTrigger(AnimationDatas.ExitFadeOut);
            yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync(indexScene);
            transitionAnimator.SetTrigger(AnimationDatas.ExitFadeIn);
            yield return new WaitForSeconds(1);
            transitionGameObject.SetActive(false);
        }
    }
}
