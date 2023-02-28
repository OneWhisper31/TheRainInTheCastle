using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public int playerHealth {set { health = value; }}

    [HideInInspector]public GridButton button;

    public override void OnHitHandler(int damageDealt)
    {
        base.OnHitHandler(damageDealt);
    }

    protected override void OnDeadHandler()
    {
        button.OnDeadAllay();
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
        b.button = null;
        b.transform.SetParent(null);
        b.gameObject.SetActive(false);
    }

    protected override Prototype Clone()//desactivado ya que no se usa para aliados
    {
        throw new System.NotImplementedException();
    }
}
