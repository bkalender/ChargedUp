using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour {

    private Hand hand;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start()
    {
        hand = GameObject.FindObjectOfType<Hand>();
        paddleToBallVector = this.transform.position - hand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // Lock the spell to the hand.
            this.transform.position = hand.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch.
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");
                hasStarted = true;
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);
            }
        }
    }
}
