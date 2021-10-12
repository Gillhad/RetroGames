using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager sharedInstance = null;
    public bool gameStarted = false;
    public Text title;
    public Button start;

    GameObject ball;
    Vector2 nextDirection;

    private void Awake()
    {
        if (sharedInstance == null) {
            sharedInstance = this;
        }
    }

    public void SartGame() {
        gameStarted = true;
        title.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoalScored() {
        ball.GetComponent<TrailRenderer>().enabled = false;  
        ball.transform.position = Vector3.zero;        
        nextDirection = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, 0); 
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Invoke("LaunchBall", 2.0f);
        
    }

    public void LaunchBall() {
        Ball b = ball.GetComponent<Ball>();        
        ball.GetComponent<Rigidbody2D>().velocity = nextDirection.normalized * b.ballSpeed;
        ball.GetComponent<TrailRenderer>().enabled = true;
    }

}
