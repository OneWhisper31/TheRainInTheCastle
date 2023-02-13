using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridButton : MonoBehaviour
{

    public GameplayGrid gameplayGrid;

    public void OnClick()
    {

        gameplayGrid.OnClick(transform);

        GetComponent<Button>().interactable=false;
    }
}
