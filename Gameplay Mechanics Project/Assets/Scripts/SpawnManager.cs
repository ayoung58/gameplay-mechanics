using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int waveNumber = 1;
    public float spawnRange = 9;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); 
    }

    void SpawnEnemyWave(int numEnemies) {
        for (int i = 0; i < numEnemies; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) {
            if (GameObject.Find("PowerIcon(Clone)") == null) {
                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); 
            }
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition() {
        float randomSpawnX = Random.Range(-spawnRange, spawnRange);
        float randomSpawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomSpawnX, 0, randomSpawnZ);
        return randomPos;
    }
}
