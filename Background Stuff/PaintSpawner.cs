using UnityEngine;

public class PaintSpawner : MonoBehaviour
{
    public GameObject newThing; // The prefab to spawn
    public float interval = 0.01f; // Time interval between spawns
    private int sortingOrder = 0;
    public float colorR, colorG, colorB;
    float timer;

    void Update()
    {
        timer += Time.deltaTime; // Increment the timer

        if (timer >= interval)
        {
            // Generate a random position within the rectangle (-2, -2) to (2, 2)
            Vector2 randomPosition = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));

            // Spawn the new object at the random position
            Color slashColor = new Color(colorR + Random.Range(-0.1f, 0.1f), colorG + Random.Range(-0.1f, 0.1f), colorB + Random.Range(-0.1f, 0.1f));
            SpawnObject(randomPosition, slashColor); // Default color (can be overridden)

            // Reset the timer
            timer = 0;
        }
    }

    // Method to spawn an object with a specific color
    public void SpawnObject(Vector2 position, Color color)
    {
        GameObject spawnedObject = Instantiate(newThing, position, Quaternion.identity);

        // Set the color of the spawned object
        SpriteRenderer spriteRenderer = spawnedObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }

        // Ensure the new object renders on top of the old ones
        spriteRenderer.sortingOrder = sortingOrder;
        sortingOrder++; // Increment the sorting order for the next object
    }
}