using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCube : Cube {

    List<GameObject> neighborCubes = new List<GameObject>();

	// Use this for initialization
	void Start () {
        //neighborCubes = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
        if (other.tag == "FireCube")
            neighborCubes.Add(other.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Spell"){
            Destroy(gameObject);

            foreach (GameObject cube in neighborCubes){
                foreach(GameObject neighbor in cube.GetComponent<FireCube>().neighborCubes){
                    if (neighbor != null)
                        Destroy(neighbor);
                }
                Destroy(cube);
            }
        }
            

        print("omg it hit me");
    }
}
