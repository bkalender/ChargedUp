using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        HandleHits();
        print("omg it hit me");
    }

    void HandleHits()
    {
        Destroy(gameObject);
    }
}
