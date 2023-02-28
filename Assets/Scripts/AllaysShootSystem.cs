using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllaysShootSystem : MonoBehaviour, IScreen
{
    [SerializeField] LayerMask enemyMask;
    public GameObject bulletPrefab;

    float currentCooldown;
    FlyweightAllays allay;
    Animator animator;
    bool IsActive=true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        AddToListEntitySM();

        switch (GetComponent<PlayerHealth>().typeOfEntity)
        {
            case TypesOfEntitys.Arquero:
                allay = FlyweightPointer.arquero;
                break;
            case TypesOfEntitys.Piromano:
                allay = FlyweightPointer.piromano;
                break;
            case TypesOfEntitys.Experto:
                allay = FlyweightPointer.experto;
                break;
            default:
                break;
        }

    }

    void Update()
    {
        if (currentCooldown > 0&&IsActive)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }
        

        if (Physics2D.Raycast(transform.position + allay.allayMinDistance * transform.right, transform.right, allay.allayMaxDistance, enemyMask))
        {
            var obj = BulletFactory.Instance.pool.GetObject();
            obj.transform.position=transform.position;

            obj.GetComponent<Bullet>().damage = allay.bulletDamage;
            currentCooldown = allay.cooldown;
        }
    }

    public void Activate()
    {
        animator.speed = 1;
        IsActive = true;

    }

    public void Deactivate()
    {
        animator.speed = 0;
        IsActive = false;
    }

    public void Free()
    {
       
    }

    public void AddToListEntitySM() //Sumo la entidad al primer push
    {
        if (SMEntity._entityList.Contains(this)) return;
        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay " + SMEntity._entityList.Count);
    }
}
