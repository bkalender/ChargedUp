using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    List<Cube> cubes = new List<Cube>();

    public GameObject[] cubePrefabs;

	void Start () {
        foreach (Cube cube in gameObject.GetComponentsInChildren<Cube>()){
            cubes.Add(cube);
        }
	}
	
	void Update () {

        int cubeListLength = gameObject.GetComponentsInChildren<Cube>().Length;

        if (cubeListLength < 4) {
            /*switch (cubeListLength){
                case 0:

                    break;

                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;


            }
            */
            int newCubeY = 0;
            int missingCubeCount = 4 - cubeListLength;

            for (int i = 0; i < missingCubeCount; i++){
                int randomCubeIndex = Random.Range(0, 3);

                GameObject newCube = Instantiate(cubePrefabs[randomCubeIndex], gameObject.transform);
                newCube.transform.localPosition = Vector3.zero + new Vector3 (0, newCubeY, 0);
                cubes.Add(newCube.GetComponent<Cube>());
                newCubeY += 4;
            }

            //newCube.transform.parent = gameObject.transform;
        }
	}
}
