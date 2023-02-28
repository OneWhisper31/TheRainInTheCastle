using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IScreen
{
    //cambias cuando instancias
    [HideInInspector]public int damage = 5;

    bool IsActive=true;

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

    private void Awake()
    {
        AddToListEntitySM();
    }

    private void Update()
    {
        if(IsActive)
        {
            lifetime -= Time.deltaTime;

            if(lifetime<=0)
                BulletFactory.Instance.ReturnBullet(this);//pool
        }    
    }

    public void AddToListEntitySM() //Sumo la entidad al primer push
    {
        if (SMEntity._entityList.Contains(this)) return;
        
        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay " + SMEntity._entityList.Count);
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

    public void Activate()
    {
        IsActive = true;
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.right * velocity;
    }

    public void Deactivate()
    {
        IsActive = false;
        rb.velocity = Vector2.zero;
    }

    public void Free()
    {
        return;
    }
}
