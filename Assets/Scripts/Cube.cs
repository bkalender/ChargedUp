using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector3 cubePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cubePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = cubePos;
    }
}
