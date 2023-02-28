using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected Animator animator;
    [HideInInspector]public FlyweightEnemies enemyType;

    protected virtual void Start()
    {
        TypesOfEntitys type = GetComponent<EnemyHealth>().typeOfEntity;

        switch (type)
        {
            case TypesOfEntitys.Zombie:
                enemyType = FlyweightPointer.zombie;
                break;
            case TypesOfEntitys.Kamikaze:
                enemyType = FlyweightPointer.kamikaze;
                break;
            case TypesOfEntitys.Blindado:
                enemyType = FlyweightPointer.blindado;
                break;
            default:
                break;
        }

        animator = GetComponent<Animator>();
    }
}
