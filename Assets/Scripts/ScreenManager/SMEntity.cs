using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMEntity : MonoBehaviour, IScreen
{
    [SerializeField]public static List<IScreen> _entityList = new List<IScreen>();

    private void Awake()
    {
        _entityList = new List<IScreen>();
        ScreenManager.Instance.Push(this);
        Debug.Log("Push de Lista en ScreemManager");
    }





    public void Activate()
    {
        foreach (var item in _entityList) // Activo todo lo de la lista Enemigos, Aliados, Ballas y tiempo de juego
        {
            if (item == null) return;
            item.Activate();
        }
    }

    public void Deactivate()
    {
        foreach (var item in _entityList)
        {
            item.Deactivate();
        }
    }

    public void Free()
    {
        foreach (var item in _entityList)
        {
            item.Free();
        }
    }
}
