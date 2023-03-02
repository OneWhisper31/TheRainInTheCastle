using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGrid : MonoBehaviour
{
    public CurrencyManager currencyManager;

    public int xSize, ySize;
    public GameObject gridButtonPrefab;

    [Header("Sonidos")]
    public GameObject _soundNegative, _SoundPeek;

    [Header("Prefab Tropas")]
    public GameObject cultivo;
    public GameObject arquero, piromano, expertos;

    //encargado de almacenar los prefabs etiquetados segun su tipo
    Buildings buildings;


    Dictionary<int[], TypesOfEntitys> grid = new Dictionary<int[], TypesOfEntitys>();//int[x,y]cords type que tiene

    public void Start()
    {
        CreateNewGrid();

        currencyManager = GetComponent<CurrencyManager>();
        buildings = new Buildings(cultivo, arquero, piromano, expertos);
    }
    void CreateNewGrid()
    {
        for (int y = 0; y < xSize; y++)
        {
            for (int x = 0; x < ySize; x++)
            {
                Add(x, y);
                int[] array = GetCoords(x, y);
                var obj = Instantiate(gridButtonPrefab, new Vector3(array[0], array[1], 0), Quaternion.Euler(Vector3.zero), this.transform);
                obj.GetComponent<GridButton>().gameplayGrid= this;
            }
        }
    }
    void Add(int x, int y, TypesOfEntitys type =TypesOfEntitys.Vacio)
    {
        int[] array = GetCoords(x, y);

        grid.Add(array, type);
    }
    public void AddBuilding(int x, int y, TypesOfEntitys type)
    {
        int[] array = GetCoords(x, y);

        grid[array] = type;
    }
    public void RemoveBuilding(int x, int y)
    {
        int[] array = GetCoords(x, y);

        grid[array] = TypesOfEntitys.Vacio;
    }
    public int[] GetCoords(int x, int y)
    {
        int[] array = new int[2];
        array[0] = x * 2 + 2;
        array[1] = y * -2 + 5;
        return array;
    }

    public bool OnClick(GridButton button)
    {
        var cost = BuildingCost();

        if (currencyManager.Currency >= cost)
        {
            currencyManager.Currency -= cost;

            PlayerHealth obj = default;

            switch (buildings.buildingSelected)
            {
                case TypesOfEntitys.Cultivo:
                    obj = EntityFactory.Instance.poolCultivo.GetObject();
                    break;
                case TypesOfEntitys.Arquero:
                    obj = EntityFactory.Instance.poolArquero.GetObject();
                    break;
                case TypesOfEntitys.Piromano:
                    obj = EntityFactory.Instance.poolPiromano.GetObject();
                    break;
                case TypesOfEntitys.Experto:
                    obj = EntityFactory.Instance.poolExperto.GetObject();
                    break;
                default:
                    obj = EntityFactory.Instance.poolCultivo.GetObject();//en caso de error, selecciona cultivo
                    break;
            }

            obj.button = button;

            obj.transform.position = button.transform.position;
            obj.transform.rotation = button.transform.rotation;
            obj.transform.SetParent(button.transform.parent);
            //var obj = Instantiate(PrefabSelected(), _transform.position, _transform.rotation, _transform);
            Destroy(Instantiate(_SoundPeek), 1);
            return true;
        }
        else
        {
            //sonido de rechazo
            Destroy(Instantiate(_soundNegative), 1);
            return false;
        }
    }

    public void ChangeSelected(int type)// segun el orden del enum
    {//busca en el diccionario el prefab segun la llave elegida
        buildings.buildingSelected = (TypesOfEntitys)type;
    }

    public int BuildingCost()
    {
        return buildings.cost[buildings.buildingSelected];
    }

    public GameObject PrefabSelected()
    {//busca en el diccionario el prefab segun la llave elegida
        return buildings.list[buildings.buildingSelected];
    }
}
public class Buildings
{
    public TypesOfEntitys buildingSelected= TypesOfEntitys.Cultivo;

    public Dictionary<TypesOfEntitys, GameObject> list = new Dictionary<TypesOfEntitys, GameObject>();
    public Dictionary<TypesOfEntitys, int> cost = new Dictionary<TypesOfEntitys, int>();

    public Buildings(GameObject Cultivo, GameObject Arquero, GameObject Piromano, GameObject Expertos)
    {
        list.Add(TypesOfEntitys.Cultivo, Cultivo);
        list.Add(TypesOfEntitys.Arquero, Arquero);
        list.Add(TypesOfEntitys.Piromano, Piromano);
        list.Add(TypesOfEntitys.Experto, Expertos);
        cost.Add(TypesOfEntitys.Cultivo, 20);
        cost.Add(TypesOfEntitys.Arquero, 50);
        cost.Add(TypesOfEntitys.Piromano, 40);
        cost.Add(TypesOfEntitys.Experto, 100);
    }
}