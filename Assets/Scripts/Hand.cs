using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour {

    public bool autoPlay = false;
    public float minX, maxX, minY, maxY;

    private Spell spell;

    void Start()
    {
        spell = GameObject.FindObjectOfType<Spell>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            AimWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 handPos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        Vector3 spellPos = spell.transform.position;
        spellPos.x = Mathf.Clamp(spellPos.x, minX, maxX);
        spellPos.y = Mathf.Clamp(spellPos.y, minY, minX);
        this.transform.position = handPos;
    }

    void AimWithMouse()
    {
        Vector3 handPos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);

        float mousePosInBlocksX = Input.mousePosition.x / Screen.width * 16;
        float mousePosInBlocksY = Input.mousePosition.y / Screen.height * 16;

        handPos.x = Mathf.Clamp(mousePosInBlocksX, minX, maxX);
        handPos.x = Mathf.Clamp(mousePosInBlocksY, minY, maxY);
        this.transform.position = handPos;
    }
}
