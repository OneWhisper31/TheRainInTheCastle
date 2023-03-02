using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _audioM;
    List<AudioSource> audioList = new List<AudioSource>();

    float volumenValue=0.42f;
    

    void Start()
    {
        if (_audioM == null)
        {
            _audioM = this; 
        }
        else Destroy(this);

        NewAudioSourceInScene(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VolumenOnChange(float volumen)
    {
        volumenValue = volumen;
        foreach (var item in audioList)
        {
            if (item == null) return;
            if (item.GetComponent<AudioSource>() == null) return;
                     item.volume = volumenValue;
        }
    }

    public void NewAudioSourceInScene(GameObject audio)
    {
        var item = audio.GetComponent<AudioSource>();
        if(item!=null)
        {
             item.volume = volumenValue; 

            if (!audioList.Contains(item))
            {
                audioList.Add(item);
                Debug.Log("Enrtro a la lista de Audio y somos" + audioList.Count);

            }
            

        } else return;

    }





}
