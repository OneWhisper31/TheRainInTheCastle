using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    int currency; public int Currency { get { return currency; } 
        set { currency = value; text.text = currency.ToString(); } }

    private void Start()
    {
        currency = 1000;//debug
        text.text = currency.ToString();
    }
}
