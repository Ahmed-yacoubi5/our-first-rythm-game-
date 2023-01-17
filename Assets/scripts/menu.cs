using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    
    public void play(string sceneName)
    {
    SceneManager.LoadScene("Levelselect");
    }
    public void credits(string sceneName)
    {
    SceneManager.LoadScene("Credits");
    }
     public void QuitGame()

    {
        Application.Quit();
    }

}



