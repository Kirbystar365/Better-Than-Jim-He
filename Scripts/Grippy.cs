using System;
using System.Threading;
using UnityEngine;




public class Grippy : MonoBehaviour
{
    public Renderer SKIN;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    SKIN = GetComponent<Renderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        SKIN.material.color = new Color(Mathf.Abs(Mathf.Sin(Time.time+2))+.1f, Mathf.Abs(Mathf.Sin(Time.time + 3)) + .1f, Mathf.Abs(Mathf.Sin(Time.time + 4)) + .1f, 1f);

    }
}

