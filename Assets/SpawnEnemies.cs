using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] Enemies[] enemy;
    [SerializeField] int dificult;
    [SerializeField] int[] amountEnemies;
    [SerializeField] int[] timeBetweenEnemies;
    [SerializeField] GameObject[] spawnsOfEnemies = new GameObject[5];
    float time;




    void Start()
    {
        dificult = 1;


    }

    // Update is called once per frame
    void Update()
    {
        SpawnOnLevel();
        time += Time.deltaTime;
    }

    public void SpawnOnLevel()
    {
       if(time>timeBetweenEnemies[dificult])
        {
            time = 0f;
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnsOfEnemies[Random.Range(0, 5)].transform.position, transform.rotation); ;
        }
    }
}
