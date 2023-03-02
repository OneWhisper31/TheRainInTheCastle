using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvas : MonoBehaviour
{
    public GameObject _OptionsCanvasGO;
    IScreen _OptionsCanvas;
    bool IsPause = false;
    public Slider _slider;


    private void Start()
    {
        _OptionsCanvas = _OptionsCanvasGO.GetComponent<IScreen>();
        _OptionsCanvas.Deactivate();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Input Pausa");
            SwitchPause();
        }
    }

    public void SwitchPause()
    {
        if(IsPause)
        {
            ScreenManager.Instance.Pop();
            IsPause = false;
            Debug.Log("Saco Pausa");

        }
        else
        {
            ScreenManager.Instance.Push(_OptionsCanvas);
            IsPause = true;
            Debug.Log("entro en pausa");
        }
    }

    public void SliderVolumen()
    {
        AudioManager._audioM.VolumenOnChange(_slider.value);
    }

}
