using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivo : MonoBehaviour
{
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

            var obj= PopupFactory.Instance.pool.GetObject();

            obj.transform.position = transform.position + new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), 0);
            obj.transform.rotation = Quaternion.Euler(Vector3.zero);
            obj.transform.SetParent(transform);

            obj.GetComponent<CurrencyPopUp>().currencyManager = currencyManager;
        }
    }
}
