using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpawned : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AudioManager._audioM.NewAudioSourceInScene(this.gameObject);
    }
}
