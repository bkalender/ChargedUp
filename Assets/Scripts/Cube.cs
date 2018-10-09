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
    }

    void HandleHits()
    {
        Destroy(gameObject);
    }
}
