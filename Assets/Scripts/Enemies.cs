using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Animator animator;
    public EnemiesSO SO;
    void Start()
    {
        
        animator = GetComponent<Animator>(); //por que no asiga?
    }
    void Update()
    {
        
    }
}
