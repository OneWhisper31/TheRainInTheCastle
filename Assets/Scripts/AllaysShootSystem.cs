using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllaysShootSystem : MonoBehaviour
{
    //distancia maxima donde el allay puede tirar
    [SerializeField] float plantMaxDistance=12;
    //distancia donde por cercania el allay deja de tirar
    [SerializeField] float plantMinDistance=0;

    [SerializeField] LayerMask enemyMask;
    public GameObject bulletPrefab;

    [SerializeField] float cooldown;
    [SerializeField] int bulletDamage;
    float currentCooldown;

    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }

        if (Physics2D.Raycast(transform.position + plantMinDistance * transform.right, transform.right, plantMaxDistance, enemyMask))
        {
            var obj = Instantiate(bulletPrefab,transform.position,Quaternion.Euler(Vector3.zero));
            obj.GetComponent<Bullet>().damage = bulletDamage;
            currentCooldown = cooldown;

            //encontrar la forma que las distancias minimas no peguen los proyectiles
                //(a lo mejor agregar un cooldown donde el proyectil no haga daño)
        }
    }
}
