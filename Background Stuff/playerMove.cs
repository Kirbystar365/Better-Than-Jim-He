using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Movement variables
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float walkForce = 5f;

    // Spawning variables
    public PaintSpawner paintSpawner; // Reference to the PaintSpawner component
    public Vector2 spawnOffset = new Vector2(0.5f, 0f); // Offset for spawning
    public Color spawnColor = new Color(1f, 0f, 0f); // Default color (red)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        // Move left
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector2(-walkForce, 0), ForceMode2D.Impulse);
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }

        // Move right
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector2(walkForce, 0), ForceMode2D.Impulse);
        }

        // Spawn object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (paintSpawner != null)
            {
                // Spawn the object with the specified offset and color
                paintSpawner.SpawnObject(spawnOffset, spawnColor);
            }
            else
            {
                Debug.LogWarning("PaintSpawner reference is not set in playerMove.");
            }
        }
    }
}