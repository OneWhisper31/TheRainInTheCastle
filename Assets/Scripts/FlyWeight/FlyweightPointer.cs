using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightPointer : MonoBehaviour
{
    public static readonly FlyweightAllays arquero = new FlyweightAllays
    {
        allayMaxDistance=12,
        allayMinDistance=0,
        cooldown=2,
        bulletDamage=5
    };
    public static readonly FlyweightAllays piromano = new FlyweightAllays
    {
        allayMaxDistance = 6,
        allayMinDistance = 0,
        cooldown = 0.4f,
        bulletDamage = 2
    };
    public static readonly FlyweightAllays experto = new FlyweightAllays
    {
        allayMaxDistance = 20,
        allayMinDistance = 3,
        cooldown = 8,
        bulletDamage = 15
    };

    public static readonly FlyweightEnemies zombie = new FlyweightEnemies
    {
        velocity=1,
        damage=5
    };
    public static readonly FlyweightEnemies kamikaze = new FlyweightEnemies
    {
        velocity = 2.5f,
        damage = (int)Mathf.Floor(Mathf.Infinity)
    };
    public static readonly FlyweightEnemies blindado = new FlyweightEnemies
    {
        velocity = 0.5f,
        damage = 10
    };

    public static readonly FlyweightHealth cultivoHealth = new FlyweightHealth
    {
        originalHealth=20
    };
    public static readonly FlyweightHealth arqueroHealth = new FlyweightHealth
    {
        originalHealth = 20
    };
    public static readonly FlyweightHealth piromanoHealth = new FlyweightHealth
    {
        originalHealth = 20
    };
    public static readonly FlyweightHealth expertoHealth = new FlyweightHealth
    {
        originalHealth = 20
    };
    public static readonly FlyweightHealth zombieHealth = new FlyweightHealth
    {
        originalHealth = 20
    };
    public static readonly FlyweightHealth kamikazeHealth = new FlyweightHealth
    {
        originalHealth = 5
    };
    public static readonly FlyweightHealth blindadoHealth = new FlyweightHealth
    {
        originalHealth = 40
    };
}
