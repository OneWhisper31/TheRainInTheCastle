using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class OnWinLoseManager : MonoBehaviour, IScreen
{
    public UnityEvent onLose;
    public UnityEvent onWin;

    [SerializeField] float winTimer= 300;//segundos
    public TextMeshProUGUI text;

    public LayerMask enemyLayer;
    bool IsActive=true;

    private void Start()
    {
        AddToListEntitySM();
    }

    public void AddToListEntitySM() //Sumo la entidad al primer push
    {
        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay " + SMEntity._entityList.Count);
    }

    private void Update()
    {
        if(IsActive)
        {
            winTimer -= Time.deltaTime;
            text.text = Math.Truncate(winTimer / 60).ToString("00") + ":" + Mathf.RoundToInt(winTimer % 60).ToString("00");

            if (winTimer <= 0) //condicion de ganar
            {
                Time.timeScale = 0;
                winTimer = 300;
                onWin.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//colision de perder
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

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Free()//No entra nunca aca
    {
        return;
    }
}
