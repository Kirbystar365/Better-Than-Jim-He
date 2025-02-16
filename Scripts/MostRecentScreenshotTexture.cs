using System;
using System.IO;
using UnityEngine;

public class MostRecentScreenshotTexture : MonoBehaviour
{
    public string screenshotFolderPath = "Screenshots"; // Relative path to the folder containing screenshots
    public SpriteRenderer targetSpriteRenderer; // The SpriteRenderer to apply the texture to
    public float imageScale;

    void Start()
    {
        // Get the most recent screenshot file
        string mostRecentFilePath = GetMostRecentScreenshotFilePath();

        if (!string.IsNullOrEmpty(mostRecentFilePath))
        {
            // Load the texture from the file
            Texture2D texture = LoadTextureFromFile(mostRecentFilePath);

            if (texture != null)
            {
                // Convert the texture to a sprite and apply it to the SpriteRenderer
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                targetSpriteRenderer.sprite = sprite;
                float scaleFactor = imageScale; // scale of final image
                targetSpriteRenderer.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
            }
            else
            {
                Debug.LogError("Failed to load texture from file: " + mostRecentFilePath);
            }
        }
        else
        {
            Debug.LogError("No screenshot files found in folder: " + screenshotFolderPath);
        }
    }

    private string GetMostRecentScreenshotFilePath()
    {
        // Get the full path to the screenshot folder
        // Navigate up one level from Assets to the project root, then add the Screenshots folder
        string fullPath = Path.Combine(Application.dataPath, "../", screenshotFolderPath);

        // Check if the folder exists
        if (!Directory.Exists(fullPath))
        {
            Debug.LogError("Screenshot folder does not exist: " + fullPath);
            return null;
        }

        // Get all files in the folder
        string[] files = Directory.GetFiles(fullPath, "*.png"); // Assuming screenshots are PNGs

        if (files.Length == 0)
        {
            Debug.LogError("No screenshot files found in folder: " + fullPath);
            return null;
        }

        // Find the most recent file based on creation time
        string mostRecentFile = null;
        DateTime mostRecentDate = DateTime.MinValue;

        foreach (string file in files)
        {
            DateTime creationTime = File.GetCreationTime(file);
            if (creationTime > mostRecentDate)
            {
                mostRecentDate = creationTime;
                mostRecentFile = file;
            }
        }

        return mostRecentFile;
    }

    private Texture2D LoadTextureFromFile(string filePath)
    {
        // Read the file into a byte array
        byte[] fileData = File.ReadAllBytes(filePath);

        // Create a new Texture2D
        Texture2D texture = new Texture2D(2, 2); // Size will be replaced when loading the image

        // Load the image data into the texture
        if (texture.LoadImage(fileData))
        {
            return texture;
        }

        return null;
    }
}