using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnPlay()
    {
        SceneManager.LoadScene("Level");
    }
}
