using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprite_renderer;
    public Sprite WalkAnimation;
    public Sprite JumpAnimation;
    public Sprite FallingAnimation;
    public float speed = 5.0f;
    public float Jump = 12.0f;


    public uint life = 3;
    public uint JumpsAvaiable = 2;

    public GameObject GroundCheck;
    private bool isGrounded;
    public LayerMask WhatIsGround;

    public GameObject fireball;

    public GameplayInterface GUI;

    void Start()
    {
        
    }

    void Update()
    {
        //set correct sprite
        if (!isGrounded)
        { 
            if (rb.velocity.y > 0.5f)
               sprite_renderer.sprite = JumpAnimation;
            else if (rb.velocity.y < -1.0f)
                sprite_renderer.sprite = FallingAnimation;
        }
        else
            sprite_renderer.sprite = WalkAnimation;
        


        //character movement
            if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                sprite_renderer.flipX = true;
            }
            else if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                sprite_renderer.flipX = false;
            }
            else
                rb.velocity = new Vector2(0.0f, rb.velocity.y);




        //jump
        if ((Input.GetKeyDown(KeyCode.Space) && JumpsAvaiable > 1) || (Input.GetKeyDown(KeyCode.Space) && isGrounded))
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
            JumpsAvaiable -= 1;
        }




        if (false)
        {
            //fireball
            if (Input.GetMouseButtonDown(1) && GUI.IsOnCooldown())
            {

                GUI.StartCooldown();
                if (sprite_renderer.flipX)
                {
                    GameObject f = Instantiate(fireball, new Vector3(transform.position.x - 0.45f, transform.position.y, transform.position.z), new Quaternion(0.5f, 0.5f, -0.5f, -0.5f));
                    f.transform.eulerAngles = new Vector3(180, -90, -90);
                    f.GetComponent<Fireball>().direction = -1.0f;
                }
                else
                {
                    GameObject f = Instantiate(fireball, new Vector3(transform.position.x + 0.45f, transform.position.y, transform.position.z), new Quaternion(0.5f, -0.5f, -0.5f, 0.5f));
                    f.GetComponent<Fireball>().direction = 1.0f;
                }
            }
        }
            
    }

    private void FixedUpdate()
    {
        //is cahracter touching platform
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, 0.2f, WhatIsGround);

        if (isGrounded)
            JumpsAvaiable = 1;
    }
}
