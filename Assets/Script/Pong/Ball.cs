using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 25;
    private bool hasTheBallMoved = false;
    private float heightCorrection = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    private void Update()
    {
        if (GameManager.sharedInstance.gameStarted && !hasTheBallMoved) {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * ballSpeed;
            hasTheBallMoved = true;
        }
        if (GameManager.sharedInstance.gameStarted) {
            string racketName = (GetComponent<Rigidbody2D>().velocity.x > 0 ? "RacketLeft" : "RacketRight");
            GameObject racket = GameObject.Find(racketName);
            GetComponent<SpriteRenderer>().color = racket.GetComponent<SpriteRenderer>().color;

            /* Esto es lo facil, hemos usado operador ternario
            if (GetComponent<Rigidbody2D>().velocity.x > 0) {
                GameObject racket = GameObject.Find("RacketLeft");
                GetComponent<SpriteRenderer>().color = racket.GetComponent<SpriteRenderer>().color;
            }
            else
            {
                GameObject racket = GameObject.Find("RacketRight");
                GetComponent<SpriteRenderer>().color = racket.GetComponent<SpriteRenderer>().color;
            }*/

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft") {
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * ballSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Buff")
        {
            StartCoroutine("Normality");
            Destroy(collision.gameObject);
        }
    }

        
    

    float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float raquetHeight) {
        
        
        return((ballPosition.y - racketPosition.y)/(raquetHeight+heightCorrection));
    }

    public void Buff() {

        float buffRandom = Random.Range(1f,5f);
        int buffNumber = (int)buffRandom;
        Debug.Log(buffNumber);
        if (buffNumber == 1)
        {
            ballSpeed += 1;
            Debug.Log("dope 1");
        }
        else if (buffNumber == 2)
        {
            ballSpeed += 5;
            Debug.Log("dope 2");
        }
        else if (buffNumber == 3)
        {
            ballSpeed += 10;
            Debug.Log("dope 3");
        }
        else {
            string racketName = (GetComponent<Rigidbody2D>().velocity.x < 0 ? "RacketLeft" : "RacketRight");
            GameObject racket = GameObject.Find(racketName);
            racket.GetComponent<Transform>().localScale = new Vector3(1f,0.5f,1f);
            Debug.Log("haste pequeña");
        }

    
    }

    IEnumerator Normality() {

        Buff();
        yield return new WaitForSeconds(4);
        ballSpeed = 25;
        GameObject racket1 = GameObject.Find("RacketLeft");
        GameObject racket2 = GameObject.Find("RacketRight");
        racket1.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        racket2.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);

    }

  
}
