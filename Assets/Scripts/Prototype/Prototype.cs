using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prototype : MonoBehaviour
{
    protected abstract Prototype Clone();
}
