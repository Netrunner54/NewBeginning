using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private float MaxHeight;
    private float MinHeight;
    public bool Up = true;

    public float DeltaHeigh = 2.0f;
    public float speed = 2.0f;
    public Rigidbody2D rb;

    private bool stop = false;
    private float StartAgain = 0.0f;
    public float StopTime = 0.35f;

    void Start()
    {
        MaxHeight = gameObject.transform.position.y + DeltaHeigh;
        MinHeight = gameObject.transform.position.y - DeltaHeigh;
    }

    // Update is called once per frame
    void Update()
    {
        if (((gameObject.transform.position.y > MaxHeight && Up != false ) || (gameObject.transform.position.y < MinHeight) && Up != true) && !stop )
        {
            Up = !Up;
            stop = true;
            StartAgain = Time.unscaledTime + StopTime;
            rb.velocity = new Vector2(0.0f, 0.0f);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Round(gameObject.transform.position.y), gameObject.transform.position.z);
        }



        if (!stop)
        {
            if (Up)
                rb.velocity = new Vector2(0.0f, speed);
            else
                rb.velocity = new Vector2(0.0f, -speed);
        }
        else
        {
            if (Time.unscaledTime > StartAgain)
                stop = false;
        }
        
    }
}
