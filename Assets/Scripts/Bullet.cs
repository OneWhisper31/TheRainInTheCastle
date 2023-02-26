using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //cambias cuando instancias
    [HideInInspector]public int damage = 5;

    [SerializeField] float velocity=10;
    Rigidbody2D rb;

    [SerializeField]float lifetime=15;

    private void OnTriggerEnter2D(Collider2D other)
    {

        var otherHealthSystem = other.GetComponent<EnemyHealth>();

        if (otherHealthSystem!=null)
        {
            otherHealthSystem.OnHitHandler(damage);
        }
        BulletFactory.Instance.ReturnBullet(this);//pool
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime<=0)
            BulletFactory.Instance.ReturnBullet(this);//pool
    }

    private void Reset()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.right * velocity;
    }

    public static void TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);
        b.Reset();
    }

    public static void TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
    }
}
