using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivo : MonoBehaviour, IScreen
{
    public CurrencyManager currencyManager;
    bool IsActive=true;
    float durationTime;
    float _time;


    private void Start()
    {
        //StartCoroutine(GiveCurrency());
        durationTime = Random.Range(5, 10f);
        AddToListEntitySM();
        currencyManager = FindObjectOfType<CurrencyManager>();

    }

    private void Update()
    {
        SpawnCurrency();
    }

    public void AddToListEntitySM() //Sumo la entidad al primer push
    {
        if (SMEntity._entityList.Contains(this)) return;

        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay " + SMEntity._entityList.Count);
    }
    IEnumerator GiveCurrency()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 25f));

            var obj= PopupFactory.Instance.pool.GetObject();

            obj.transform.position = transform.position + new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), 0);
            obj.transform.rotation = Quaternion.Euler(Vector3.zero);
            obj.transform.SetParent(transform);

            obj.GetComponent<CurrencyPopUp>().currencyManager = currencyManager;
        }
    }

    void SpawnCurrency()
    {
        if(IsActive)
        {
            _time += Time.deltaTime;

            if(_time>durationTime)
            {
                _time = 0;
                durationTime = Random.Range(5, 10f);
                var obj = PopupFactory.Instance.pool.GetObject();
                obj.transform.position = transform.position + new Vector3(Random.Range(-1, 1.1f), Random.Range(-1, 1.1f), 0);
                obj.transform.rotation = Quaternion.Euler(Vector3.zero);
                obj.transform.SetParent(transform);

                obj.GetComponent<CurrencyPopUp>().currencyManager = currencyManager;
            }   
        }
    }
    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Free()
    {
       
    }
}
