using UnityEngine;

public class healthbar : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] healthFrames; // Assign sliced sprites in Inspector

    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (Globals.jimHealth >= 80) spriteRenderer.sprite = healthFrames[5];
        else if (Globals.jimHealth >= 60) spriteRenderer.sprite = healthFrames[4];
        else if (Globals.jimHealth >= 40) spriteRenderer.sprite = healthFrames[3];
        else if (Globals.jimHealth >= 20) spriteRenderer.sprite = healthFrames[2];
        else if (Globals.jimHealth > 0) spriteRenderer.sprite = healthFrames[1];
        else
        {
            spriteRenderer.sprite = healthFrames[0];
        }
    }
}
