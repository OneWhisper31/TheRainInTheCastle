using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGrid : MonoBehaviour
{
    [SerializeField]int currency;

    public int xSize, ySize;
    public GameObject gridButtonPrefab;

    [Header("Prefab Tropas")]
    public GameObject cultivo;
    public GameObject arquero, piromano, torre;

    //encargado de almacenar los prefabs etiquetados segun su tipo
    Buildings buildings;


    Dictionary<int[], TypeOfBuildings> grid = new Dictionary<int[], TypeOfBuildings>();//int[x,y]cords type que tiene

    public void Start()
    {
        CreateNewGrid();

        buildings = new Buildings(cultivo, arquero, piromano, torre);
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
    void Add(int x, int y, TypeOfBuildings type=TypeOfBuildings.Vacio)
    {
        int[] array = GetCoords(x, y);

        grid.Add(array, type);
    }
    public void AddBuilding(int x, int y, TypeOfBuildings type)
    {
        int[] array = GetCoords(x, y);

        grid[array] = type;
    }
    public void RemoveBuilding(int x, int y)
    {
        int[] array = GetCoords(x, y);

        grid[array] = TypeOfBuildings.Vacio;
    }
    public int[] GetCoords(int x, int y)
    {
        int[] array = new int[2];
        array[0] = x * 2 + 2;
        array[1] = y * -2 + 5;
        return array;
    }

    public void OnClick(Transform _transform)
    {
        var cost = BuildingCost();

        if (currency >= cost)
        {
            currency -= cost;
            Instantiate(PrefabSelected(), _transform.position, _transform.rotation, _transform);
        }
        else
        {
            //sonido de rechazo
        }
    }

    public void ChangeSelected(int type)// segun el orden del enum
    {//busca en el diccionario el prefab segun la llave elegida
        buildings.buildingSelected = (TypeOfBuildings)type;
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

public enum TypeOfBuildings
{
    Cultivo,
    Arquero,
    Piromano,
    Torre,
    Vacio
}
public class Buildings
{
    public TypeOfBuildings buildingSelected;

    public Dictionary<TypeOfBuildings, GameObject> list = new Dictionary<TypeOfBuildings, GameObject>();
    public Dictionary<TypeOfBuildings, int> cost = new Dictionary<TypeOfBuildings, int>();

    public Buildings(GameObject Cultivo, GameObject Arquero, GameObject Piromano, GameObject Torre)
    {
        list.Add(TypeOfBuildings.Cultivo, Cultivo);
        list.Add(TypeOfBuildings.Arquero, Arquero);
        list.Add(TypeOfBuildings.Piromano, Piromano);
        list.Add(TypeOfBuildings.Torre, Torre);
        cost.Add(TypeOfBuildings.Cultivo, 20);
        cost.Add(TypeOfBuildings.Arquero, 50);
        cost.Add(TypeOfBuildings.Piromano, 40);
        cost.Add(TypeOfBuildings.Torre, 100);
    }
}