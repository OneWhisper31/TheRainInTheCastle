using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BdeathEnemy : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += SO.velocity * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Tower>() != null)
        {
            //atacar
        }
    }

    //Caminata
    
}
