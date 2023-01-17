using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
   
    public void Level1(string sceneName)
    {
    SceneManager.LoadScene("lvl 1");
    }
    public void Level2(string sceneName)
    {
    SceneManager.LoadScene("lvl 2");
    }
    public void Level3(string sceneName)
    {
    SceneManager.LoadScene("lvl 3");
    }
    public void Level4(string sceneName)
    {
    SceneManager.LoadScene("lvl 4");
    }
   


}
