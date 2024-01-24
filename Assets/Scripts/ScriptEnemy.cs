using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnYMin, spawnYMax;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {

    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(1047, Random.Range(spawnYMin, spawnYMax), 0);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            Vector3 direction = new Vector3(-1, 0, 0);

            enemy.GetComponent<EnemyController>().SetDirection(direction);

            yield return new WaitForSeconds(2.0f);
        }
    }
}