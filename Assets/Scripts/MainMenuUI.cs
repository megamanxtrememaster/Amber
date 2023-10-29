using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
  
    public void ClickStart()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
