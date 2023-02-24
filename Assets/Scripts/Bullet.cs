using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //cambias cuando instancias
    [HideInInspector]public int damage = 5;

    [SerializeField] float velocity=10;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        var otherHealthSystem = other.GetComponent<EnemyHealth>();

        if (otherHealthSystem!=null)
        {
            otherHealthSystem.OnHitHandler(damage);
        }
        Destroy(this.gameObject);//pool
    }
}
