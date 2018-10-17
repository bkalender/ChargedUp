using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DelayedDestroy", 2f);
	}
	
    void DelayedDestroy(){
        Destroy(gameObject);
    }
}
