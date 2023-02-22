using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public int playerHealth {set { health = value; }}

    public override void OnHitHandler(int damageDealt)
    {
        base.OnHitHandler(damageDealt);
    }

    protected override void OnDeadHandler()
    {
        base.OnDeadHandler();
    }
}
