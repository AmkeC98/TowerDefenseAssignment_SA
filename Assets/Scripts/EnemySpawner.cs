using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] pathPoints;
    public float spawnDelay = 2f;
    public int enemiesPerWave = 5;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyObj.GetComponent<Enemy>().Init(pathPoints);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
