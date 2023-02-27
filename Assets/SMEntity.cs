using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMEntity : MonoBehaviour, IScreen
{
    [SerializeField]public static List<IScreen> _entityList = new List<IScreen>();

    private void Awake()
    {
        ScreenManager.Instance.Push(this);
        Debug.Log("Push de Lista en ScreemManager");
    }





    public void Activate()
    {
        foreach (var item in _entityList)
        {
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
