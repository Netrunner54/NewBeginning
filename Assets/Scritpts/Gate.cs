using UnityEngine;

public class Gate : MonoBehaviour
{
    public Trigger trigger;
    public float speed = 0.0f;
    private float StartPositionY;

    // Start is called before the first frame update
    void Start()
    {
        StartPositionY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.active)
        { 
            if (gameObject.transform.position.y < StartPositionY + 1.0f)
                speed = 1.0f;
            else
                speed = 0.0f;
        }
        else if (gameObject.transform.position.y > StartPositionY)
            speed = -1.0f;
        else
            speed = 0.0f;



        gameObject.transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
    }
}
