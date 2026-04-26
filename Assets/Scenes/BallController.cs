using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public float maxForce = 10f;
    public LineRenderer lineRenderer;

    private Rigidbody2D rb;
    private Vector2 dragStart;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        if (Mouse.current == null) return;
        

        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            dragStart = mouseWorld;
            isDragging = true;
        }

        if (Mouse.current.leftButton.isPressed && isDragging)
        {
            Vector2 diff = dragStart - mouseWorld;
            if (diff.magnitude > maxForce) diff = diff.normalized * maxForce;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, (Vector2)transform.position + diff);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && isDragging)
        {
            Vector2 diff = dragStart - mouseWorld;
            if (diff.magnitude > maxForce) diff = diff.normalized * maxForce;

            rb.AddForce(diff * maxForce, ForceMode2D.Impulse);
            GameManager.Instance.UseAttempt();
            Invoke("CallCheckLose", 1.5f);
            isDragging = false;
            lineRenderer.enabled = false;
        }
    }
    void OnEnable()
    {
        isDragging = false;
        lineRenderer.enabled = false;
    }
    void CallCheckLose()
    {
        GameManager.Instance.CheckLose();
    }
}