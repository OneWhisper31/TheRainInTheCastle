using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridButton : MonoBehaviour
{

    public GameplayGrid gameplayGrid;

    public Color usedColor;
    Color unusedColor;

    bool used;

    Image image;

    private void Start()
    {
        unusedColor = GetComponent<Image>().color;
    }

    public void OnClick()
    {
        if (used)
            return;

        if (gameplayGrid.OnClick(this))//return true si se ejecuto
        {
            if (image == null)
                image = GetComponent<Image>();
            image.color = usedColor;
            used = !used;
        }
    }
    public void OnDeadAllay()
    {
        image.color = unusedColor;
        used = false;
    }
}
