using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalZone : MonoBehaviour
{
    int score;
    public Text scoreText;
    private void Awake()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("han marcado");
            score+=1;
            scoreText.text = score.ToString();
            GameManager.sharedInstance.GoalScored();
        }
    }
}
