using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    enum CubeType { Fire, Frost, Arcane }
    private CubeType cubeType;
    private Transform cubeTransform;
    List<GameObject> neighborCubes = new List<GameObject>();

    [HideInInspector]
    public Rigidbody rb;
    
    public ParticleSystem fireParticle;
    public ParticleSystem frostParticle;
    public ParticleSystem arcaneParticle;


    void Start(){
        cubeTransform = gameObject.transform;
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.velocity);

        if(gameObject.tag == "FireCube")
        {
            cubeType = CubeType.Fire;
        } else if (gameObject.tag == "FrostCube")
        {
            cubeType = CubeType.Frost;
        } else if (gameObject.tag == "ArcaneCube")
        {
            cubeType = CubeType.Arcane;
        }

        Debug.Log(cubeType);
    }

    private void OnTriggerStay(Collider other)
    {
        if (rb.velocity == Vector3.zero)
        {
            if (other.tag == gameObject.tag)
            if(!neighborCubes.Contains(other.gameObject))
                neighborCubes.Add(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Spell")
        {
            foreach (GameObject cube in neighborCubes)
            {
                if(cube != null){
                    foreach (GameObject neighbor in cube.GetComponent<Cube>().neighborCubes)
                    {
                        if (neighbor != null)
                            Destroy(neighbor);
                    }
                    Destroy(cube);
                }

            }
            Destroy(gameObject);
        }


        print("omg it hit me");
    }

    private void OnDestroy()
    {
        switch (cubeType){
            case CubeType.Fire:
                ParticleSystem newParticle = Instantiate(fireParticle);
                newParticle.transform.position = cubeTransform.position;
                break;
            case CubeType.Frost:
                Instantiate(frostParticle);
                break;
            case CubeType.Arcane:
                Instantiate(arcaneParticle);
                break;
            default:
                break;

        }
    }
}
