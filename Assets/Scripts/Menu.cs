using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EasyLevel()
    {
        SceneManager.LoadScene("Easy");
    }

    public void HardLevel()
    {
        SceneManager.LoadScene("Hard");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
