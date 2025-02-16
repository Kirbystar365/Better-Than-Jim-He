using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SirAndrew : MonoBehaviour
{
    public GameObject hideShow;
    private Rigidbody2D rb;
   
    void Start()
    {
        hideShow = GameObject.Find("Andy-O’Fallon_0");

        hideShow.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        if (Globals.win == true)
        {
            hideShow.GetComponent<Renderer>().enabled = true;
        }
    }
}
