using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManadgerInGame : MonoBehaviour
{
    [SerializeField] GameObject pauseGamePanel;
    [SerializeField]  GameObject gamePanelUI;
    private bool gameOnPause;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(gameOnPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        gameOnPause = false;
        pauseGamePanel.SetActive(false);
        gamePanelUI.SetActive(true);
    }

    public void Pause()
    {
        pauseGamePanel.SetActive(true);
        Time.timeScale = 0.001f;
        gameOnPause = true;
        gamePanelUI.SetActive(false);
    }
}
