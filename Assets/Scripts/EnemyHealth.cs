using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    SpriteRenderer sprite;
    public GameObject _explosion;


    public override void OnHitHandler(int damageDealt)
    {
        base.OnHitHandler(damageDealt);

    }

    protected override void OnDeadHandler()
    {
        if (typeOfEntity == TypesOfEntitys.Blindado)
        {
            Clone().GetComponent<EnemyHealth>().typeOfEntity=TypesOfEntitys.Kamikaze;//actua como un kamikaze
        }
        SpawnSoundAndFX();
        base.OnDeadHandler();
    }

    private void Reset()
    {
        switch (typeOfEntity)
        {
            case TypesOfEntitys.Zombie:
                health=FlyweightPointer.zombieHealth.originalHealth;
                break;
            case TypesOfEntitys.Kamikaze:
                health = FlyweightPointer.kamikazeHealth.originalHealth;
                break;
            case TypesOfEntitys.Blindado:
                health = FlyweightPointer.blindadoHealth.originalHealth;
                break;
            default:
                break;
        }

        if (sprite == null)
            sprite = GetComponent<SpriteRenderer>();

        this.NormalColor();
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


    protected override Prototype Clone()
    {
        EnemyHealth obj;
        switch (typeOfEntity)
        {
            case TypesOfEntitys.Zombie:
                obj = EntityFactory.Instance.poolZombie.GetObject().GetComponent<EnemyHealth>();
                break;
            case TypesOfEntitys.Kamikaze:
                obj = EntityFactory.Instance.poolKamikaze.GetObject().GetComponent<EnemyHealth>();
                break;
            case TypesOfEntitys.Blindado:
                obj = EntityFactory.Instance.poolBlindado.GetObject().GetComponent<EnemyHealth>();
                break;
            default://en caso de error, zombie
                obj = EntityFactory.Instance.poolZombie.GetObject().GetComponent<EnemyHealth>();
                break;
        }
        obj.RandomColor()
            .SetPosition(transform.position.x+2,transform.position.y,transform.position.z);


        return obj;
    }


    public EnemyHealth NormalColor()
    {
        Color color = Color.white;
        color.a = 1;

        sprite.color = color;


        return this;
    }

    public EnemyHealth RandomColor()
    {
        Color color = Random.ColorHSV(0.4f, 0.8f);
        color.a = 1;

        sprite.color = color;


        return this;
    }
    public EnemyHealth SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);

        return this;
    }

    void SpawnSoundAndFX()
    {
        Destroy(Instantiate(_explosion, transform.position, transform.rotation), 1);
    }
}
