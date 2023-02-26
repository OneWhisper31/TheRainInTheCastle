using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class OnWinLoseManager : MonoBehaviour
{
    public UnityEvent onLose;
    public UnityEvent onWin;

    [SerializeField] float winTimer= 300;//segundos
    public TextMeshProUGUI text;

    public LayerMask enemyLayer;

    private void Update()
    {
        winTimer -= Time.deltaTime;
        text.text = Math.Truncate(winTimer / 60).ToString("00") + ":" + Mathf.RoundToInt(winTimer % 60).ToString("00");

        if (winTimer <= 0)
        {
            Time.timeScale = 0;
            winTimer=300;
            onWin.Invoke();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

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
