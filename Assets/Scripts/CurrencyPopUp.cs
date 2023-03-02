using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPopUp : MonoBehaviour
{
    public CurrencyManager currencyManager;
    public GameObject _soundPeek;

    public int onCurrencyAdd;

    public void OnClick()
    {
        Destroy(Instantiate(_soundPeek), 1);
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
        if(gameObject.activeInHierarchy==false)
            gameObject.SetActive(true);

        StartCoroutine(Dissapear());
    }

    public static void TurnOn(CurrencyPopUp b)
    {
        b.gameObject.SetActive(true);
        b.Reset();
    }

    public static void TurnOff(CurrencyPopUp b)
    {
        b.StopAllCoroutines();
        b.gameObject.SetActive(false);
    }
}
