using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public TypesOfEntitys typeOfEntity;

    [SerializeField] protected int health;

    [SerializeField] protected int originalHealth;

    //[SerializeField]Animator anim;

    public int _Health { get{ return health; } }

    private void Start()
    {
        originalHealth = health;
    }

    public virtual void OnHitHandler(int damageDealt)
    {
        health -= damageDealt;

        if (health <= 0)
            OnDeadHandler();
    }
    protected virtual void OnDeadHandler()
    {
        //anim.SetTrigger("isDead");
        Debug.Log("Perdio " + gameObject.name);
        EntityFactory.Instance.ReturnEntity(typeOfEntity,this);//pool
    }
}
