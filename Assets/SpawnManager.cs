using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUp; 
    public GameObject enemy;
    private int waveNumber = 1;
    public float spawnRange = 9f;

    // Start is called before the first frame update
    void Start()
    {
        Spawn(waveNumber);
    }

    private void Update()
    {
        int enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            Spawn(++waveNumber);
        }
    }

    // Update is called once per frame
    void Spawn(int wave)
    {
        Instantiate(powerUp, GetSpawnLocation(), powerUp.transform.rotation);

        for (int i = 0; i <= wave; i++)
        {
            Instantiate(enemy, GetSpawnLocation(), enemy.transform.rotation);
        }
    }
    Vector3 GetSpawnLocation()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
    }
}
