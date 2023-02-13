using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGrid : MonoBehaviour
{
    public int xSize, ySize;
    public GameObject gridButtonPrefab;
    public GameObject troupPrefab;//despues va a ser un array

    Dictionary<int[], TypeOfBuildings> grid = new Dictionary<int[], TypeOfBuildings>();//int[x,y]cords type que tiene

    public void Start()
    {
        CreateNewGrid();
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
        Instantiate(troupPrefab, _transform.position, _transform.rotation, _transform);
    }

    /*private void OnDrawGizmos()
    {

        for (int y = 0; y < xSize; y++)
        {
            for (int x = 0; x < ySize; x++)
            {
                Gizmos.DrawCube(new Vector3(x*2+2, y*-2+5, 0),Vector3.one*1.8f);
            }
        }
    }*/
}

public enum TypeOfBuildings
{
    Cultivo,
    Arquero,
    Piromano,
    Torre,
    Vacio
}