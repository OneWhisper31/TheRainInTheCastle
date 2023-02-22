using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int health;

    [SerializeField]Animator anim;

    public int _Health { get{ return health; } }

    public virtual void OnHitHandler(int damageDealt)
    {
        health -= damageDealt;

        if (health <= 0)
            OnDeadHandler();
    }
    protected virtual void OnDeadHandler()
    {
        anim.SetTrigger("isDead");
        Debug.Log("Perdio " + gameObject.name);
        Destroy(this.gameObject);
    }
}
