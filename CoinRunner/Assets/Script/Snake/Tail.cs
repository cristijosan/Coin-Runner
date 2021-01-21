using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tail : MonoBehaviour
{
    int nrOfCoins = 0;

    public Text score;
    public Transform Head;
    public float CoinDiameter = 0.2f;

    private List<Transform> coins = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    void Awake() {
        positions.Add(Head.position);
        score.text = nrOfCoins.ToString();
    }

    void Update() {
        float distance = ((Vector3)Head.position - positions[0]).magnitude;

        if (distance > CoinDiameter) {
            Vector3 direction = ((Vector3) Head.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CoinDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CoinDiameter;
        }

        for (var i = 0; i < coins.Count; i++) {
            coins[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CoinDiameter);
        }
        score.text = nrOfCoins.ToString();
    }

    public void AddCoins() {
        nrOfCoins++;
        Transform coin = Instantiate(Head, positions[positions.Count - 1], Quaternion.identity, transform);
        coin.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        coins.Add(coin);
        positions.Add(coin.position);
    }
}
