using UnityEngine;
using UnityEngine.SceneManagement;
#if HAS_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Lightbug.CharacterControllerPro.Demo
{
    public class MainMenuManager : MonoBehaviour
    {
        string mainMenuName = "";
        static MainMenuManager instance = null;
        public static MainMenuManager Instance => instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                mainMenuName = SceneManager.GetActiveScene().name;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        public void GoToScene(string sceneName)
        {
            if (sceneName == mainMenuName)
                Cursor.visible = true;
            else
                Cursor.visible = false;

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        void Update()
        {
#if HAS_INPUT_SYSTEM && ENABLE_INPUT_SYSTEM
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
#elif ENABLE_LEGACY_INPUT_MANAGER
            if (Input.GetKeyDown(KeyCode.Escape))
#else
            if (false)  
#endif
            {
                if (SceneManager.GetActiveScene().name == mainMenuName)
                    Application.Quit();
                else
                    GoToScene(mainMenuName);
            }
        }
    }
}