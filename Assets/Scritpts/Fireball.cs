using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float direction = 1.0f;
    public float speed = 15.0f;

    public ParticleSystem Explosion;
    public ParticleSystem Tail;

    public bool ShouldBeDestroyed = false;
    private float DestructionTime = 0.0f;
    void Start()
    {
        Explosion.Stop();
    }

    
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * direction * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);

        if(ShouldBeDestroyed)
        {
            if (DestructionTime < Time.unscaledTime)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion.Play();
        Destroy(Tail);
        Explosion.Emit(100);
        speed = 0.0f;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        ShouldBeDestroyed = true;
        DestructionTime = Time.unscaledTime + 0.6f;
    }
}
