using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour, IScreen
{
    [SerializeField] Enemies[] enemy;
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
        SMEntity._entityList.Add(this);
        Debug.Log("Sumo a la lista y hay " + SMEntity._entityList.Count);
    }

    public void SpawnOnLevel()
    {
       if(time>timeBetweenEnemies[dificult])
        {
            time = 0f;

            //TypesOfEntitys contiene las entidades enumeradas y es la key para llamar al pool 5,6,7 son de zombies,
            //y cada uno tiene su propia pool, por eso es recomendable q hagas un switch como t dejo abajo
            //para que tengas en cuenta cuando hagas los otros enemigos

            //int random = Random.Range(5, 8); // tipos de zombies, de ahi  
            //
            //switch ((TypesOfEntitys)random)
            //{
            //    case TypesOfEntitys.Zombie:
            //        EntityFactory.Instance.poolZombie.GetObject();
            //        break;
            //    case TypesOfEntitys.Kamikaze:
            //        EntityFactory.Instance.poolKamikaze.GetObject();
            //        break;
            //    case TypesOfEntitys.Blindado:
            //        EntityFactory.Instance.poolBlindado.GetObject();
            //        break;
            //    default:
            //        break;
            //}

            //las pools de kamikaze y blindado estan comentadas, tenes q descomentarlas para que no tire error je

            var obj = EntityFactory.Instance.poolZombie.GetObject();

            obj.transform.position = spawnsOfEnemies[Random.Range(0, 5)].transform.position;
            obj.transform.rotation = transform.rotation;

            //Instantiate(enemy[Random.Range(0, enemy.Length)], spawnsOfEnemies[Random.Range(0, 5)].transform.position, transform.rotation);
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
