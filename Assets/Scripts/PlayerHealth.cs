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

    private void Reset()
    {
        switch (typeOfEntity)
        {
            case TypesOfEntitys.Cultivo:
                health = FlyweightPointer.cultivoHealth.originalHealth;
                break;
            case TypesOfEntitys.Arquero:
                health = FlyweightPointer.arqueroHealth.originalHealth;
                break;
            case TypesOfEntitys.Piromano:
                health = FlyweightPointer.piromanoHealth.originalHealth;
                break;
            case TypesOfEntitys.Experto:
                health = FlyweightPointer.expertoHealth.originalHealth;
                break;
        }
    }

    public static void TurnOn(PlayerHealth b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(PlayerHealth b)
    {
        b.gameObject.SetActive(false);
        b.transform.SetParent(null);
    }
}
