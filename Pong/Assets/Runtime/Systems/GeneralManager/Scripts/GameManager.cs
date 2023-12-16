using UnityEngine;

namespace Runtime.Systems.GeneralManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        #region Don't Destroy This Game Object
        public void DontDestroyThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        private void Awake()
        {
            DontDestroyThisGameObject();
        }
    }
}
