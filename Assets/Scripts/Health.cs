using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : Prototype
{
    public TypesOfEntitys typeOfEntity;

    [SerializeField] protected int health;

    //[SerializeField] protected int originalHealth;

    //[SerializeField]Animator anim;

    public int _Health { get{ return health; } }

    private void Start()
    {

        switch (typeOfEntity)
        {
            case TypesOfEntitys.Vacio:
                break;
            case TypesOfEntitys.Cultivo:
                FlyweightPointer.cultivoHealth.originalHealth = health;
                break;
            case TypesOfEntitys.Arquero:
                FlyweightPointer.arqueroHealth.originalHealth = health;
                break;
            case TypesOfEntitys.Piromano:
                FlyweightPointer.piromanoHealth.originalHealth = health;
                break;
            case TypesOfEntitys.Experto:
                FlyweightPointer.expertoHealth.originalHealth = health;
                break;
            case TypesOfEntitys.Zombie:
                FlyweightPointer.zombieHealth.originalHealth = health;
                break;
            case TypesOfEntitys.Kamikaze:
                FlyweightPointer.kamikazeHealth.originalHealth = health;
                break;
            case TypesOfEntitys.Blindado:
                FlyweightPointer.blindadoHealth.originalHealth = health;
                break;
            default:
                break;
        }
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
