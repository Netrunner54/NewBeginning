using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        
    }


    void Update()
    {
        if (rb.velocity.y < -1f)
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Sdsd");
        if (collision.collider.attachedRigidbody)
        {
            if (collision.collider.gameObject.tag == "Fireball")
            {
                Destroy(gameObject);
            }
        }
    }
}
