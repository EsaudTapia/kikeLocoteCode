using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    
    public GameObject[] enemies;

    public float timeSpawn = 1;
    public float RepeatSpawnRate = 3;


    public Transform xRangeLeft;
    public Transform xRangeRight;

    public Transform yRangeUp;
    public Transform yRangeDown;

    public GameObject[] fruits;
    public float timeSpawnFruits = 1;
    public float RepeatSpawnRateFruits = 3;

    public float difficulyTime=0;






    void Start()
    {
       StartCoroutine("EnemyDifficulty");
       StartCoroutine("FruitsDifficulty");
        
    }

    // Update is called once per frame
    void Update()
    {
        difficulyTime += Time.deltaTime;

        if (difficulyTime > 10 && difficulyTime < 20)
        {
            RepeatSpawnRate = 2f;
            RepeatSpawnRateFruits = 3.5f;
            
        }

        if (difficulyTime > 20 && difficulyTime < 30)
        {
            RepeatSpawnRate = 1;
            RepeatSpawnRateFruits = 4f;
            
        }

        if (difficulyTime > 30 && difficulyTime < 50)
        {
            RepeatSpawnRate = 0.75f;
            RepeatSpawnRateFruits = 5f;
            
        }

        if (difficulyTime > 50 )
        {
            RepeatSpawnRate = 0.25f;
            
        }
      
    }

    IEnumerator EnemyDifficulty(){
        yield return new WaitForSeconds(RepeatSpawnRate);
        SpawnEnemies();
        StartCoroutine("EnemyDifficulty");
    }

     IEnumerator FruitsDifficulty(){
        yield return new WaitForSeconds(RepeatSpawnRateFruits);
        SpawnFruits();
        StartCoroutine("FruitsDifficulty");
    }

   
   

public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);
        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x,xRangeRight.position.x),Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);
        GameObject enemie= Instantiate(enemies[Random.Range(0,enemies.Length)],spawnPosition, gameObject.transform.rotation);
   }


   public void SpawnFruits()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);
        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x,xRangeRight.position.x),Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);
        GameObject fruit= Instantiate(fruits[Random.Range(0,fruits.Length)],spawnPosition, gameObject.transform.rotation);
   }

}
























