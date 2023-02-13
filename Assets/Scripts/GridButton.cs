using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridButton : MonoBehaviour
{

    public GameplayGrid gameplayGrid;

    public Color usedColor;

    public bool used;

    Image image;

    public void OnClick()
    {
        if (used)
            return;

        if (gameplayGrid.OnClick(transform))//return true si se ejecuto
        {
            if (image == null)
                image = GetComponent<Image>();
            image.color = Color.Lerp(image.color, usedColor, 0.5f);
            used = !used;
        }
    }
}
