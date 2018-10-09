using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour {

    private Hand hand;
    private bool hasStarted = false;
    private Vector2 handToSpellVector;

    // Use this for initialization
    void Start()
    {
        hand = GameObject.FindObjectOfType<Hand>();
        handToSpellVector = transform.position - hand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Lock the spell to the hand
        if(!hasStarted)
        LockSpellToHand();

        // Launch the spell upon mouse click
        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse clicked, launch ball");
            hasStarted = true;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);
        }
    }

    private void LockSpellToHand(){
        Vector2 handPos = new Vector2(hand.transform.position.x, hand.transform.position.y);
        transform.position = handPos + handToSpellVector;
    }
}
