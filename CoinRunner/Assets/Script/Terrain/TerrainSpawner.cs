using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject Terrain;
    Vector3 SpawnPoint;

    public void Spawn() {
        GameObject temp = Instantiate(Terrain, SpawnPoint, Quaternion.identity);
        temp.transform.SetParent(this.transform);
        SpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    void Start() {
        for (int i = 0; i < 15; i++) {
            Spawn();
        }
    }
}
