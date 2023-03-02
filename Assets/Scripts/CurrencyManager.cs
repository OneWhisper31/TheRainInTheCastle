using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    [SerializeField]int currency; public int Currency { get { return currency; } 
        set { currency = value; text.text = currency.ToString(); } }

    private void Start()
    {
        text.text = currency.ToString();
    }
}
