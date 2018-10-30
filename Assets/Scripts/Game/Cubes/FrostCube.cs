using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostCube : Cube {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FrostBolt")
            Destroy(gameObject);

        print("omg it hit me");
    }
}
