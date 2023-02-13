using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivo : MonoBehaviour
{
    public GameObject popupPrefab;

    public CurrencyManager currencyManager;

    private void Start()
    {
        StartCoroutine(GiveCurrency());
    }
    IEnumerator GiveCurrency()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10f));


            var obj =Instantiate(popupPrefab,transform.position+new Vector3(Random.Range(-1,1.1f), Random.Range(-1, 1.1f),0),
                Quaternion.Euler(Vector3.zero), transform);

            obj.GetComponent<CurrencyPopUp>().currencyManager = currencyManager;
        }
    }
}
