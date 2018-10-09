using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour {

    [SerializeField] public float minX, maxX, minY, maxY;

    private Spell spell;

    void Start()
    {
        spell = GameObject.FindObjectOfType<Spell>();
    }

    // Update is called once per frame
    void Update()
    {
            AimWithMouse();  
    }


    void AimWithMouse()
    {
        float mousePosInUnitsX = Input.mousePosition.x / Screen.width * 20;
        float mousePosInUnitsY = Input.mousePosition.y / Screen.height * 11;

        Vector2 handPos = new Vector2(this.transform.position.x, this.transform.position.y);

        handPos.x = Mathf.Clamp(mousePosInUnitsX, minX, maxX);
        handPos.y = Mathf.Clamp(mousePosInUnitsY, minY, maxY);
        this.transform.position = handPos;
    }
}
