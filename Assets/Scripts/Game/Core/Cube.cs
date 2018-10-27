using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    enum CubeType { Fire, Frost, Arcane }
    private CubeType cubeType;
    private Transform cubeTransform;
    List<GameObject> neighborCubes = new List<GameObject>();
    List<GameObject> destroyArray = new List<GameObject>();
    [HideInInspector]
    public Rigidbody rb;
    
    public ParticleSystem fireParticle;
    public ParticleSystem frostParticle;
    public ParticleSystem arcaneParticle;

    private List<GameObject> DFS(List<GameObject> foundNeighbors, CubeType typeToSearch){
        if (foundNeighbors.Contains(this.gameObject)) return foundNeighbors;
        if (this.cubeType != typeToSearch) return foundNeighbors;
        foundNeighbors.Add(this.gameObject);
        foreach(GameObject neighbor in neighborCubes){
            foundNeighbors = neighbor.GetComponent<Cube>().DFS(foundNeighbors, typeToSearch);
        }
        return foundNeighbors;

    }
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
       
            if (other.tag == gameObject.tag)
            if(!neighborCubes.Contains(other.gameObject))
                neighborCubes.Add(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {
        if (neighborCubes.Contains(other.gameObject))
            neighborCubes.Remove(other.gameObject);
    }
    /*public List<GameObject> DestroyNeighbors(){
        if (neighborCubes.Count == 0)
        {
            destroyArray.Add(gameObject);
            return destroyArray;
        }
        else
        {
            if (!destroyArray.Contains(gameObject))
            {
                destroyArray.Add(gameObject);
            }
            foreach (GameObject neighbor in neighborCubes)
            {
                return destroyArray.Add(neighbor.GetComponent<Cube>().DestroyNeighbors());

            }

        }
            
       

    }*/

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FireSpell" && gameObject.tag == "FireCube" || 
            col.gameObject.tag == "FrostSpell" && gameObject.tag == "FrostCube" || 
            col.gameObject.tag == "ArcaneSpell" && gameObject.tag == "ArcaneCube" )
        {
            List<GameObject> toDestroy = new List<GameObject>();
            toDestroy = DFS(toDestroy, this.cubeType);
            foreach(GameObject cubes in toDestroy){
                Destroy(cubes);
            }
            /*
            foreach (GameObject cube in neighborCubes)
            {
                if(cube != null){
                    foreach (GameObject neighbor in cube.GetComponent<Cube>().neighborCubes)
                    {
                        if (neighbor != null)
                        {
                            foreach(GameObject nextNeighbor in neighbor.GetComponent<Cube>().neighborCubes)
                            {
                                if(nextNeighbor != null)
                                Destroy(nextNeighbor);
                            }
                            Destroy(neighbor);
                        }

                    }
                    Destroy(cube);
                }

            }
            Destroy(gameObject);
        */
        }

        
        print("omg it hit me");
    }

    private void OnDestroy()
    {
        switch (cubeType){
            case CubeType.Fire:
                ParticleSystem newFireParticle = Instantiate(fireParticle);
                newFireParticle.transform.position = cubeTransform.position;
                break;
            case CubeType.Frost:
                ParticleSystem newFrostParticle = Instantiate(frostParticle);
                newFrostParticle.transform.position = cubeTransform.position;
                break;
            case CubeType.Arcane:
                ParticleSystem newArcaneParticle = Instantiate(arcaneParticle);
                newArcaneParticle.transform.position = cubeTransform.position;
                break;
            default:
                break;

        }
    }
}
