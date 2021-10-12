using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArkanoidUI : MonoBehaviour
{
    public Image life1, life2, life3;
    BallAk ball;
    private bool hasTheGameEnded = false;
    private float gameTime = 0.0f;
    public Text durationText;

    private void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<BallAk>();

    }

    private void Update()
    {
        if (hasTheGameEnded) {
            return;
        }
        if(ball.lives < 3)
        {
            life3.enabled = false;
        }
        if (ball.lives < 2)
        {
            life2.enabled = false;
        }
        if (ball.lives < 1)
        {
            life1.enabled = false;
        }
        gameTime += Time.deltaTime;
        durationText.text = gameTime.ToString("N2");
    }

}
