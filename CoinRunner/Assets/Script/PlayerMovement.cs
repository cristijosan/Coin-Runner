using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Tail tail;
    public AudioSource coinSound;

    public float movementHorizontalSpeed = 10f;
    public float movementVerticalSpeed = 10f;

    void Start() {
        tail = GameObject.FindObjectOfType<Tail>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal") * movementHorizontalSpeed;

        transform.Translate(new Vector3(horizontal, 0, movementVerticalSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Coin") {
            coinSound.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject, 0);
            tail.AddCoins();
        }
        if (collision.gameObject.tag == "Obstacle") {
            SceneManager.LoadScene(0);
        }
    }
}
