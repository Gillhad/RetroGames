using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BallAk : MonoBehaviour
{
    public float ballSpeed = 5f;
    public Vector2 startPosition;
    public int lives = 3;

    private void Start()
    {
        StartPosition();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle") {
            float x = HitFactor(
                this.transform.position,
                collision.transform.position,
                collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "OOlimits") {
            lives--;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().position = startPosition;
            Invoke("StartPosition",2.0f);
        }
    }

    public float HitFactor(Vector2 ballPosition, Vector2 paddle, float paddleWidth ) {
        return ((ballPosition.x-paddle.x)/paddleWidth);

    }

    private void StartPosition() {
        startPosition = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Rigidbody2D>().position + new Vector2(0, 1);
        GetComponent<Rigidbody2D>().position = startPosition;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, -1) * ballSpeed;

    }

}
