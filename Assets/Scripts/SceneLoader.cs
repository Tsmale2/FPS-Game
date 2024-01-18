using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    { 
        print("quitting game");
        Application.Quit();
       
    }
}
