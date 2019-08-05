using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    [SerializeField] GameObject enemy;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] int secondsBetweenSpawn = 2;
    [SerializeField] AudioClip enemySpawnedSFX;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());   
    }

    IEnumerator SpawnEnemy()
    {
        for (int i =0; i<numberOfEnemies; i++)
        {
            GetComponent<AudioSource>().PlayOneShot(enemySpawnedSFX);
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
