using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTerrain : MonoBehaviour
{
    private void OnTriggerExit(Collider collision) {
        if (collision.gameObject.name == "Player") {
            Destroy(gameObject, 2);
        }
    }
}
