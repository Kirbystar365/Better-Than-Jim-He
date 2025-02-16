using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class OpenSesame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Canvas pausePanel; // Assign in inspector

    void Start()
    {
        pausePanel = GetComponent<Canvas>();
        
        if (pausePanel.enabled == true)
        {
            pausePanel.enabled= false;
        }
        else
        {
            pausePanel.enabled = false;
        }
    }
 
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) && pausePanel.enabled == false))
            pausePanel.enabled = true;
    }
}