using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;
    public Transform startPoint;

    private Transform currentTarget;

    void Start()
    {
        currentTarget = pointB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.05f)
        {
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            other.transform.position = startPoint.position;
        }
    }
}