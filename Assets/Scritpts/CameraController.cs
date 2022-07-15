using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject character;
    public Rigidbody2D rb;
    //private float CameraSpeed = 7.0f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (character.transform.position.x > gameObject.transform.position.x + 5.0f)
            rb.velocity = new Vector2(character.GetComponent<CharacterController>().speed + 0.01f , rb.velocity.y);
        else if (character.transform.position.x < gameObject.transform.position.x - 5.0f)
            rb.velocity = new Vector2(-(character.GetComponent<CharacterController>().speed) - 0.01f, rb.velocity.y);
        else
            rb.velocity = new Vector2(0.0f, rb.velocity.y);


        if (character.transform.position.y < gameObject.transform.position.y - 3.0f)
        {
            if (character.GetComponent<Rigidbody2D>().velocity.y < 0.0f)
                rb.velocity = new Vector2(rb.velocity.x, character.GetComponent<Rigidbody2D>().velocity.y);
            else
                rb.velocity = new Vector2(rb.velocity.x, -7.5f);
        }
        else if (character.transform.position.y > gameObject.transform.position.y + 2.0f)
            rb.velocity = new Vector2(rb.velocity.x, character.GetComponent<Rigidbody2D>().velocity.y);
        else
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
    }
}
