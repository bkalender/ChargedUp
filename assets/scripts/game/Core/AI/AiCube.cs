using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

public class AiCube : MonoBehaviour {

    public enum AiCubeType { Fire, Frost, Arcane }
    public AiCubeType cubeType;
    private Transform cubeTransform;
    public List<GameObject> neighborCubes = new List<GameObject>();

    [HideInInspector]
    public Rigidbody rb;
    public float score = 5f;

    public ParticleSystem fireParticle;
    public ParticleSystem frostParticle;
    public ParticleSystem arcaneParticle;

    // Slider


     public List<GameObject> DFS(List<GameObject> foundNeighbors, AiCubeType typeToSearch)
    {
        if (foundNeighbors.Contains(this.gameObject)) return foundNeighbors;
        if (this.cubeType != typeToSearch) return foundNeighbors;
        foundNeighbors.Add(this.gameObject);
        foreach (GameObject neighbor in neighborCubes)
        {
            foundNeighbors = neighbor.GetComponent<AiCube>().DFS(foundNeighbors, typeToSearch);
        }
        return foundNeighbors;

    }


    void Start()
    {
        cubeTransform = gameObject.transform;
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.velocity);




        if (gameObject.tag == "FireCube")
        {
            cubeType = AiCubeType.Fire;
        }
        else if (gameObject.tag == "FrostCube")
        {
            cubeType = AiCubeType.Frost;
        }
        else if (gameObject.tag == "ArcaneCube")
        {
            cubeType = AiCubeType.Arcane;
        }

        Debug.Log(cubeType);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == gameObject.tag)
            if (!neighborCubes.Contains(other.gameObject))
                neighborCubes.Add(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {
        if (neighborCubes.Contains(other.gameObject))
            neighborCubes.Remove(other.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FireSpell" && gameObject.tag == "FireCube" ||
            col.gameObject.tag == "FrostSpell" && gameObject.tag == "FrostCube" ||
            col.gameObject.tag == "ArcaneSpell" && gameObject.tag == "ArcaneCube")
        {
            List<GameObject> toDestroy = new List<GameObject>();
            toDestroy = DFS(toDestroy, this.cubeType);
            foreach (GameObject cubes in toDestroy)
            {
                Destroy(cubes);
                AiPlayer.aiScore += score;
                AiPlayer.aiScoreField.text = "Ai-Score:" + AiPlayer.aiScore;


            }

        }


       
    }

    private void OnDestroy()
    {
        switch (cubeType)
        {
            case AiCubeType.Fire:
                ParticleSystem newFireParticle = Instantiate(fireParticle);
                newFireParticle.transform.position = cubeTransform.position;
                break;
            case AiCubeType.Frost:
                ParticleSystem newFrostParticle = Instantiate(frostParticle);
                newFrostParticle.transform.position = cubeTransform.position;
                break;
            case AiCubeType.Arcane:
                ParticleSystem newArcaneParticle = Instantiate(arcaneParticle);
                newArcaneParticle.transform.position = cubeTransform.position;
                break;
            default:
                break;

        }
    }
}
