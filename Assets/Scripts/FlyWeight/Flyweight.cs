using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightAllays
{
    //distancia maxima donde el allay puede tirar
    public float allayMaxDistance;
    //distancia donde por cercania el allay deja de tirar
    public float allayMinDistance;
    //cooldown entre balas
    public float cooldown;
    public int bulletDamage;
}
public class FlyweightHealth
{
    public int originalHealth;
}