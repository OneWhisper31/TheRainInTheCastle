using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour, IScreen
{
    [SerializeField] enemy[] enemies;

    //[SerializeField] Enemies[] enemy;
    [SerializeField] int dificult;
    [SerializeField] int[] amountEnemies;
    [SerializeField] int[] timeBetweenEnemies;
    [SerializeField] GameObject[] spawnsOfEnemies = new GameObject[5];
    float time;
    bool IsActive;




    void Start()
    {
        dificult = 1;
        AddToListEntitySM();
        IsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActive)
        {
            SpawnOnLevel();
            time += Time.deltaTime;
        }
    }

    public void AddToListEntitySM() //Sumo la entidad al primer push
    {
        if (SMEntity._entityList.Contains(this)) return;
        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay " + SMEntity._entityList.Count);
    }

    public void SpawnOnLevel()
    {
       if(time>timeBetweenEnemies[dificult])
        {
            time = 0f;

            int totalpercentaje = 0;//usado para calcular la probabildad total

            for (int i = 0; i < enemies.Length; i++)
            {
                totalpercentaje+=enemies[i].percentageOfSpawn;//suma toda la probabildad
            }

            int randomEntity = Random.Range(0, totalpercentaje);//tira numero al azar de todos las probabilidades

            int acummulatePercentaje = 0;//va chequeando uno por uno si entra en la probabilidad
            EnemyHealth obj;//guarda el enemigo para trabajarlo

            for (int i = 0; i < enemies.Length; i++)
            {
                acummulatePercentaje += enemies[i].percentageOfSpawn;//se prepara para chequear la siguiente probabilidad

                if (randomEntity <= acummulatePercentaje)//si esta dentro, que analice los tipos de zombie q tiene
                {
                    switch (enemies[i].type)
                    {
                        case TypesOfEntitys.Zombie:
                            obj = EntityFactory.Instance.poolZombie.GetObject();
                            break;
                        case TypesOfEntitys.Kamikaze:
                            obj = EntityFactory.Instance.poolKamikaze.GetObject();
                            break;
                        case TypesOfEntitys.Blindado:
                            obj = EntityFactory.Instance.poolBlindado.GetObject();
                            break;
                        default:
                            obj = EntityFactory.Instance.poolZombie.GetObject();
                            //en caso de que se rompa por una mala seleccion del tipo, que genere uno normal
                            break;
                    }

                    //asigna propiedades
                    obj.transform.position = spawnsOfEnemies[Random.Range(0, spawnsOfEnemies.Length)].transform.position;

                    break;//rompe el bucle
                }
            }
        }
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;  
    }

    public void Free()
    {
        return;
    }
}

[System.Serializable]
public struct enemy
{
    public TypesOfEntitys type;//usado para spawnear del pool
    public int percentageOfSpawn;//porcentaje de spawneo
}
