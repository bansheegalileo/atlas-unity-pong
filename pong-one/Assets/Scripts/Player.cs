using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey; // up keycode 
    public KeyCode downKey; // down keycode

    public float speed = 5f; // paddle speed
    public float minY = -2.5f; // min y
    public float maxY = 2.5f; // max y
    public float buffer = 0.1f; //buffer

    // ud
    void Update()
    {
        // move paddle based on input
        if (Input.GetKey(upKey) && transform.position.y < maxY - buffer)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(downKey) && transform.position.y > minY + buffer)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}