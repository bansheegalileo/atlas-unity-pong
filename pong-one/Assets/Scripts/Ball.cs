using UnityEngine;
using System.Collections;
using UnityEditor;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 5f; // Init ball speed
    private Rigidbody2D rb;
    private Vector2 initialDirection;
    private GameManager gameManager;

    public GameObject ballstart;
    public float ZOOM = 1.6f;

    // Start b4 first frame
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    // called once per frame
    void Update()
    {
    }

    // randomlaunch
    void LaunchBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = ballstart.transform.position;
        // random direction generator
        float randomAngle = Random.Range(90f, 270f);
        initialDirection = Quaternion.AngleAxis(randomAngle, Vector3.forward) * Vector2.up;

        // apply force
        rb.velocity = initialDirection * initialSpeed;
    }


    // collisions
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("bound"))
        {
            // bounce on the top and bottom
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            rb.velocity *= ZOOM;
        }
        if (other.CompareTag("Goal"))
        {
            // p1scor
            gameManager.Score(true);
            LaunchBall();
        }
        else if (other.CompareTag("GoalTwo"))
        {
            // p2scor
            gameManager.Score(false);
            LaunchBall();
        }
        if (other.CompareTag("Paddle"))
        {
            // sweet spot ricochet
            float deltaY = transform.position.y - other.transform.position.y;
            float normalizedDeltaY = deltaY / (other.bounds.size.y / 2);
            float angle = normalizedDeltaY * 45f; 

            // new direction calc
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;

            // apply new direction
            rb.velocity = direction * initialSpeed;
            rb.velocity *= ZOOM;
        }
    }
}
