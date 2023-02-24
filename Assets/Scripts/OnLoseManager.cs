using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnLoseManager : MonoBehaviour
{
    public UnityEvent onLose;

    public LayerMask enemyLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" ");

        if (other.gameObject.layer != enemyLayer)
        {
            Time.timeScale = 0;
            onLose.Invoke();
        }
    }
    public void OnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
