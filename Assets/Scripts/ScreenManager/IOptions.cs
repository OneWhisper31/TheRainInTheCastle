using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOptions : MonoBehaviour, IScreen
{
    public void Activate()//prender canvas
    {

        this.gameObject.SetActive(true);
        Debug.Log("activo pausa");
    }

    public void Deactivate() // Apagar canvas
    {
        this.gameObject.SetActive(false);
        Debug.Log("Desactivo pausa");
    }

    public void Free() // No eliminar el canvas ya que solo se aactiva y descactiva
    {
        this.gameObject.SetActive(false);
        Debug.Log("Desactivo pausa");
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
