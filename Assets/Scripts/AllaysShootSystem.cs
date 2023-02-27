using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllaysShootSystem : MonoBehaviour
{
    [SerializeField] LayerMask enemyMask;
    public GameObject bulletPrefab;

    float currentCooldown;
    FlyweightAllays allay;

    private void Start()
    {

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
        if (currentCooldown > 0)
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
}
