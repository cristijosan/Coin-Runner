using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrain : MonoBehaviour
{
    TerrainSpawner terrainSpawner;
    public GameObject[] obstaclesPrefab;
    public GameObject coinPrefab;

    void Start() {
        terrainSpawner = GameObject.FindObjectOfType<TerrainSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.name == "Player") {
            terrainSpawner.Spawn();
            Destroy(gameObject, 2);
        }
    }

    void SpawnObstacle() {
        int ObstacleIndex = Random.Range(0, 4);
        int ObstacleSpawnIndex = Random.Range(2, 8);
        int CoinSpawnIndex = Random.Range(8, 11);

        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex);
        Transform spawnPointCoin = transform.GetChild(CoinSpawnIndex);

        GameObject temp = Instantiate(obstaclesPrefab[ObstacleIndex], spawnPoint.position, Quaternion.identity, transform);
        GameObject temp1 = Instantiate(coinPrefab, spawnPointCoin.position, Quaternion.identity, transform);
        temp.transform.SetParent(spawnPoint.transform);
        temp1.transform.SetParent(spawnPoint.transform);
    }
}
