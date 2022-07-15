using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool active = false;

    private float DefaultPositionY;

    void Start()
    {
        DefaultPositionY = gameObject.transform.position.y; 
    }

    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Barrel" || collision.collider.tag == "Player")
        {
            active = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, DefaultPositionY - 0.2f, 0.0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Barrel" || collision.collider.tag == "Player")
        {
            active = false;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, DefaultPositionY, 0.0f);
        }
    }
}
