using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("Start");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("DoorScene");
    }
}
