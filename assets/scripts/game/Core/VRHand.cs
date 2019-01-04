using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ChargedUp.Settings;

public class VRHand : MonoBehaviour
{

    [SerializeField] public float minX, maxX, minY, maxY;

    enum spellType { FIRE, FROST, ARCANE }
    private spellType currentSpellType;

    // Slider Codes, to be deleted
    public Slider slider;
    public Image fillImg;

    public Color MinFire = new Color(255, 221, 0); //FFDD00
    public Color MaxFire = new Color(255, 85, 0); //FF5500

    public Color MinFrost = new Color(167, 223, 214); //A7DFD6
    public Color MaxFrost = new Color(120, 200, 199); //78C8C7

    public Color MinArcane = new Color(180, 49, 244); //B431F4
    public Color MaxArcane = new Color(96, 24, 72); //601848

    public GameObject spellPrefab;
    public GameObject fireSpellPrefab;
    public GameObject frostSpellPrefab;
    public GameObject arcaneSpellPrefab;
    private GameObject newSpell;
    private GameObject spell;
    private float zAxis = 8f;

    void Start()
    {
        switch (GlobalAttributes.PlayerMage)
        {
            case MageType.FireMage:
                fillImg.color = Color.red;
                break;
            case MageType.FrostMage:
                fillImg.color = Color.cyan;
                break;
            case MageType.ArcaneMage:
                fillImg.color = Color.magenta;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpell();
        if (spell != null)
        {
            spell.gameObject.transform.position = gameObject.transform.position;
            ShootSpell();
        }
        if (Input.GetKeyDown(KeyCode.Space) && slider.value == slider.maxValue)
        {
            slider.value = 0f;
        }
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    void ShootSpell()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            spell.transform.parent = null;
            spell.GetComponent<Rigidbody>().velocity = spell.transform.forward*10;
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
            spell.transform.rotation = gameObject.transform.rotation;
            spell.transform.parent = gameObject.transform;
        }
    }
    void ChangeSpell()
    {
        if (Input.GetKey("q") || OVRInput.GetDown(OVRInput.Button.One))
        {
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(fireSpellPrefab);
            currentSpellType = spellType.FIRE;
            spell = newSpell;
            spell.transform.rotation = gameObject.transform.rotation;
            spell.transform.parent = gameObject.transform;
            print("destroyed");
        }
        else if (Input.GetKey("w") || OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(frostSpellPrefab);
            currentSpellType = spellType.FROST;
            spell = newSpell;
            spell.transform.rotation = gameObject.transform.rotation;
            spell.transform.parent = gameObject.transform;
            print("destroyed");
        }
        else if (Input.GetKey("e") || OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            if (spell != null)
                Destroy(spell);
            newSpell = Instantiate(arcaneSpellPrefab);
            currentSpellType = spellType.ARCANE;
            spell = newSpell;
            spell.transform.rotation = gameObject.transform.rotation;
            spell.transform.parent = gameObject.transform;
            print("destroyed");
        }
    }
}
