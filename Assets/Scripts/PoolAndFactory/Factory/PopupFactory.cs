using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupFactory : MonoBehaviour
{
    public static PopupFactory Instance
    {
        get
        {
            return _instance;
        }
    }
    static PopupFactory _instance;

    [SerializeField] CurrencyPopUp popupPrefab;

    [SerializeField] int _bulletStock = 10;

    public ObjectPool<CurrencyPopUp> pool;


    void Awake()
    {
        _instance = this;

        pool = new ObjectPool<CurrencyPopUp>(PopUpCreator, CurrencyPopUp.TurnOn, CurrencyPopUp.TurnOff, _bulletStock);
    }

    CurrencyPopUp PopUpCreator()
    {
        return Instantiate(popupPrefab);
    }

    public void ReturnPopUp(CurrencyPopUp b)
    {
        pool.ReturnObject(b);
    }
}
