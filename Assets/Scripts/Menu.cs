using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EasyLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void HardLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
