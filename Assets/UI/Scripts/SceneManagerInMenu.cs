using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerInMenu : MonoBehaviour
{
    public void RestartGame()
    { 
        SceneManager.LoadScene(1);
       //  _SceneTransition.SetActive(true);
       // _SceneTransition.GetComponent<TestTransition>().StartAnimation();
       
    }
}
