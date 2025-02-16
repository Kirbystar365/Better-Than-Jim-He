using UnityEngine;
using System.IO;

public class ScreenshotCapture : MonoBehaviour
{
    public string folderName = "Screenshots"; // Folder name to save screenshots
    public KeyCode screenshotKey = KeyCode.P; // Key to trigger screenshot
    //public bool win;
    public GameObject[] dontshow;
    void Update()
    {
        // Check if the screenshot key is pressed
        if (Globals.win)
        {
            for (int i = 0; i < dontshow.Length; i++)
            if (dontshow[i] != null) {
                dontshow[i].SetActive(false); // Hide
            }
            CaptureScreenshot();
            Globals.win = false;
        }
    }

    void CaptureScreenshot()
    {
        // Create the folder if it doesn't exist
        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
        }

        // Generate a filename with a timestamp
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        string fileName = $"{folderName}/screenshot_{timestamp}.png";

        // Capture the screenshot
        ScreenCapture.CaptureScreenshot(fileName);

        // Log the file path
        Debug.Log($"Screenshot saved to: {Path.GetFullPath(fileName)}");
    }
}