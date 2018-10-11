using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour {

    [SerializeField] public float minX, maxX, minY, maxY;

    public GameObject spellPrefab;
    private GameObject newSpell;
    private Spell spell;
    private float zAxis = 8f;

    void Start()
    {
        spell = GameObject.FindObjectOfType<Spell>();
    }

    // Update is called once per frame
    void Update()
    {
        AimWithMouse();
        spell.gameObject.transform.position = gameObject.transform.position;
        ShootSpell();
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
            newSpell = Instantiate(spellPrefab);
            spell = newSpell.GetComponent<Spell>();
        }
    }
}
