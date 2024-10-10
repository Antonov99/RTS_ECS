using UnityEngine;

namespace DefaultNamespace.GameSystems
{
    public class GameManager:MonoBehaviour
    {
        public static GameManager gameManager;
        
        void Awake ()
        {
            gameManager = this;
        }

        public void OnFinish()
        {
            Time.timeScale = 0f;
            Debug.Log("GameOver");
        }
    }
}