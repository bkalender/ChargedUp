using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ChargedUp.Settings;
using System.Collections.Generic;
using System;

public class AiHand : MonoBehaviour {



    enum spellType { FIRE, FROST, ARCANE }
    private spellType currentSpellType;


    public GameObject spellPrefab;
    public GameObject fireSpellPrefab;
    public GameObject frostSpellPrefab;
    public GameObject arcaneSpellPrefab;
    private GameObject newSpell;
    private GameObject spell;
    private float zAxis = -8.45f;
    private int nextUpdate = 1;

    private float handMoveDuration = 1.5f;
    private float handSpellDelay = 1.0f;
    private float handMoveDelay = GlobalAttributes.Difficulty;

    void Start()
    {
        StartCoroutine(AimAndShoot());
    }

    // Update is called once per frame
    void Update()
    {
        if(spell != null)
        spell.gameObject.transform.position = gameObject.transform.position;
       /* if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 5;
            // Call your fonction
            UpdateEverySecond();
        }
    */

    }

    private void UpdateEverySecond()
    {
        AimToCube();
        if (spell != null)
        {
            ShootSpell();
        }
    }

    IEnumerator AimAndShoot(){
        while(true){
            print(handMoveDelay);
            yield return new WaitForSeconds(handMoveDelay);
            StartCoroutine(AimToCube());
            yield return new WaitForSeconds(handMoveDuration+handSpellDelay);
            if (spell != null)
            {
                ShootSpell();
            }
        }
    }

    public GameObject ToShoot()
    {
        int min = 0;
        AiCube toShoot = new AiCube();
        List<GameObject> longestList = new List<GameObject>();
        foreach(AiCube aiCube in FindObjectsOfType<AiCube>()){
            List<GameObject> temp = new List<GameObject>();
            temp = aiCube.DFS(temp, aiCube.cubeType);
            if(temp.Count > min){
                toShoot = aiCube;
                longestList = temp;
                min = longestList.Count;
            }
        }
        ChangeSpell(toShoot);
        return toShoot.gameObject;
    }

    IEnumerator AimToCube()
    {
        Vector3 currentHandPos = this.gameObject.transform.position;
        Vector3 newHandPos = new Vector3();
        newHandPos = ToShoot().transform.position;
        newHandPos.z = zAxis;
        float elapsedTime = 0;

        while(elapsedTime < handMoveDuration){
            this.gameObject.transform.position = Vector3.Lerp(currentHandPos, newHandPos, (elapsedTime / handMoveDuration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        this.gameObject.transform.position = newHandPos;


    }
    void ShootSpell()
    {
       
            spell.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 10f);
            switch (currentSpellType)
            {
                case spellType.FIRE:
                    newSpell = Instantiate(fireSpellPrefab);
                    break;
                case spellType.FROST:
                    newSpell = Instantiate(frostSpellPrefab);
                    break;
                case spellType.ARCANE:
                    newSpell = Instantiate(arcaneSpellPrefab);
                    break;
            }
            spell = newSpell;

    }
    void ChangeSpell(AiCube aiCube)
    {
        if (aiCube.cubeType == AiCube.AiCubeType.Fire)
        {
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(fireSpellPrefab);
            currentSpellType = spellType.FIRE;
            spell = newSpell;
            spell.gameObject.transform.position = gameObject.transform.position;
            print("destroyed");
        }
        else if (aiCube.cubeType == AiCube.AiCubeType.Frost)
        {
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(frostSpellPrefab);
            currentSpellType = spellType.FROST;
            spell = newSpell;
            spell.gameObject.transform.position = gameObject.transform.position;
            print("destroyed");
        }
        else if (aiCube.cubeType == AiCube.AiCubeType.Arcane)
        {
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(arcaneSpellPrefab);
            currentSpellType = spellType.ARCANE;
            spell = newSpell;
            spell.gameObject.transform.position = gameObject.transform.position;
            print("destroyed");
        }
    }
}