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

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(15f);
        PopupFactory.Instance.ReturnPopUp(this);

        yield break;
    }

    private void Reset()
    {
        StopAllCoroutines();
        StartCoroutine(Dissapear());
    }

    public static void TurnOn(CurrencyPopUp b)
    {
        b.gameObject.SetActive(true);
        b.Reset();
    }

    public static void TurnOff(CurrencyPopUp b)
    {
        b.gameObject.SetActive(false);
    }
}
