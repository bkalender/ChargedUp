using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : Spell {

    private bool hasStarted = false;


    void Update()
    {
        // Lock the spell to the hand
        if (!hasStarted)
        {
            // Launch the spell upon mouse click
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");
                hasStarted = true;
                StartCoroutine(SpellTimeout());
                //this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);
            }
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    IEnumerator SpellTimeout()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
