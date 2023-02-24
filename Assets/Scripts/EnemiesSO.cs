using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/enemies", order = 1)]
public class EnemiesSO : ScriptableObject
{
    //BDeath
    public int life;
    public Vector3 velocity = new Vector2(-1,0);


}
