using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarCollider : MonoBehaviour {

    public BoxCollider2D one;
    public BoxCollider2D two;
    public BoxCollider2D three;

    public GameObject ball;
    public SpriteRenderer floor;
    public SpriteRenderer floor2;
    public SpriteRenderer ball2;

    public CircleCollider2D ballCollider;
    public Rigidbody2D rb;

    public float posX;
    public float height;
    public float width;
    public float ballWidth;

    public static bool shrinkBall;

    void Start () {
        shrinkBall = true;
        ball = GameObject.FindGameObjectWithTag("Ball");
        Rigidbody2D ballRb = rb.GetComponent<Rigidbody2D>();
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
        ballWidth = ballCollider.bounds.size.x;
    }

    // Update is called once per frame
    void Update () {
        if (ball.transform.position.y > 2.8f )
        {
            one.GetComponent<BoxCollider2D>().isTrigger = false;
            two.GetComponent<BoxCollider2D>().isTrigger = false;
            ball2.sortingLayerName = "New Layer";
        }

        if (ball.transform.position.y < -8 || ball.transform.position.x > 5 || ball.transform.position.x < -5)
        {
            ball.gameObject.transform.localScale = new Vector3(0.28f, 0.28f, 0f);
            three.GetComponent<BoxCollider2D>().enabled = true;
            one.GetComponent<BoxCollider2D>().isTrigger = true;
            two.GetComponent<BoxCollider2D>().isTrigger = true;
            ball2.sortingLayerName = "Default";
            ballCollider.sharedMaterial = null;
            floor.sortingOrder = 0;
            floor2.sortingOrder = -1;
            rb.velocity = new Vector3(0, 0, 0);
            rb.freezeRotation = true;
            if ((Score.num >= 5 && Score.num < 10) || (Score.num >= 15 && Score.num < 20) || 
                (Score.num >= 25 && Score.num < 30) || (Score.num >= 35 && Score.num < 40) || 
                Score.num >= 45)
            {
                posX = Random.Range(-((width/2) - (ballWidth/2)), ((width/2) - (ballWidth/2)));
                ball.gameObject.transform.position = new Vector3(posX, -3.1f, 0f);
            }
            else
            {
                ball.gameObject.transform.position = new Vector3(0f, -3.1f, 0f);
            }
        }
        if (ball.transform.position.y > -2 && ball.gameObject.transform.localScale != new Vector3(0.18f, 0.18f, 0f))
        {
            if (shrinkBall == true)
            {
                ball.gameObject.transform.localScale -= new Vector3(0.0025f, 0.0025f, 0f);
                floor.sortingOrder = 1;
                floor2.sortingOrder = 0;
                three.GetComponent<BoxCollider2D>().enabled = false;
                rb.freezeRotation = false;
                rb.transform.Rotate(0, 0, -500 * Time.deltaTime);
            }

        }


    }
}
