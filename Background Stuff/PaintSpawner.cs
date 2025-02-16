using UnityEngine;

public class PaintSpawner : MonoBehaviour
{
    public GameObject newThing; // The prefab to spawn
    private int sortingOrder = 1;

    // Method to spawn an object with a specific color and offset
    public void SpawnObject(Vector2 offset, Color color)
    {
        // Calculate the spawn position and rotation
        Vector2 spawnPosition = transform.TransformPoint(offset);
        Quaternion spawnRotation = transform.rotation;

        // Spawn the new object
        GameObject spawnedObject = Instantiate(newThing, spawnPosition, spawnRotation);

        // Flip the spawned object's texture if the calling object is flipped in the x-direction
        SpriteRenderer spriteRenderer = spawnedObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (transform.localScale.x < 0)
            {
                spriteRenderer.flipX = true; // Flip the texture horizontally
            }
            spriteRenderer.color = color; // Set the color
            spriteRenderer.sortingOrder = sortingOrder; // Set the sorting order
        }

        sortingOrder++; // Increment the sorting order for the next object
    }
}