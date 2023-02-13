using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPopUp : MonoBehaviour
{
    public CurrencyManager currencyManager;

    public int onCurrencyAdd;

    public void OnClick()
    {
        currencyManager.Currency += onCurrencyAdd;

        StopAllCoroutines();

        Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(Dissapear());
    }
    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);

        yield break;
    }
}
