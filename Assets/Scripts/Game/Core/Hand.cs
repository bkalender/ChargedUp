using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour {

    [SerializeField] public float minX, maxX, minY, maxY;

    enum spellType { FIRE, FROST, ARCANE }
    private spellType currentSpellType;

    public GameObject spellPrefab;
    public GameObject fireSpellPrefab;
    public GameObject frostSpellPrefab;
    public GameObject arcaneSpellPrefab;
    private GameObject newSpell;
    private GameObject spell;
    private float zAxis = 8f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpell();
        AimWithMouse();
        if(spell != null){
            spell.gameObject.transform.position = gameObject.transform.position;
            ShootSpell();
        }

    }


    void AimWithMouse()
    {
        Vector3 handPos = Input.mousePosition;
        handPos.z = zAxis; // Set this to be the distance you want the object to be placed in front of the camera.
        this.transform.position = Camera.main.ScreenToWorldPoint(handPos);

    }
    void ShootSpell()
    {
        if(Input.GetMouseButtonDown(0))
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
    }
    void ChangeSpell(){
        if(Input.GetKey("q")){
            if(spell != null)
                Destroy(spell);
            newSpell = Instantiate(fireSpellPrefab);
            currentSpellType = spellType.FIRE;
            spell = newSpell;
            print("destroyed");
        }
        else if(Input.GetKey("w")){
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(frostSpellPrefab);
            currentSpellType = spellType.FROST;
            spell = newSpell;
            print("destroyed");
        }
        else if(Input.GetKey("e")){
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(arcaneSpellPrefab);
            currentSpellType = spellType.ARCANE;
            spell = newSpell;
            print("destroyed");
        }
    }
}
