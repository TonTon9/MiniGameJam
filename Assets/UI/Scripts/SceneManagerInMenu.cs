using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerInMenu : MonoBehaviour
{
    public void RestartGame()
    { 
        SceneManager.LoadScene("SityScene");
    }
}
