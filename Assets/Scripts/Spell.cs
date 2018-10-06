using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    [SerializeField] Cube cube;
    [SerializeField] float launchX = 2f;
    [SerializeField] float launchY = 20f;

    Vector3 cubeToBallVector;
    bool hasStarted = false;

    // Use this for initialization
    void Start()
    {
        cubeToBallVector = transform.position - cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockSpellToPlayer();
            LaunchSpellOnMouseClick();
        }
    }

    private void LockSpellToPlayer()
    {
        Vector3 cubePos = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z);
        transform.position = cubePos + cubeToBallVector;
    }

    private void LaunchSpellOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
        }
    }
}
