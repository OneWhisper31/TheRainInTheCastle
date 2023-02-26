using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    public override void OnHitHandler(int damageDealt)
    {
        base.OnHitHandler(damageDealt);

    }

    protected override void OnDeadHandler()
    {
        base.OnDeadHandler();
    }

    private void Reset()
    {
        health = originalHealth;
    }

    public static void TurnOn(EnemyHealth b)
    {
        b.gameObject.SetActive(true);
        b.Reset();
    }

    public static void TurnOff(EnemyHealth b)
    {
        b.gameObject.SetActive(false);
    }
}
