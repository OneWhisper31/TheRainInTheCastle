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
}
