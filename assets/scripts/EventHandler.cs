using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using ChargedUp.Settings;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour {

    public Material FireSky;
    public Material FrostSky;
    public Material ArcaneSky;

    public ParticleSystem fireParticle;
    public ParticleSystem frostParticle;
    public ParticleSystem arcaneParticle;

    // Use this for initialization
    void Start () {
       
        if (Player.mageType == MageType.FireMage)
            RenderSettings.skybox = FireSky;
        else if (Player.mageType == MageType.FrostMage)
            RenderSettings.skybox = FrostSky;
        else if (Player.mageType == MageType.ArcaneMage)
            RenderSettings.skybox = ArcaneSky;
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.playerScore > 1000.0f)
            WinScreen();
        else if (AiPlayer.aiScore > 1000.0f)
            LossScreen();

    }

    void SprinkleParticles()
    {
        while (true){
            int cubeType = Random.Range(1, 4);
            switch (cubeType)
            {
                case 1:
                    ParticleSystem newFireParticle = Instantiate(fireParticle);
                    newFireParticle.transform.position = gameObject.transform.position;
                    break;
                case 2:
                    ParticleSystem newFrostParticle = Instantiate(frostParticle);
                    newFrostParticle.transform.position = gameObject.transform.position;
                    break;
                case 3:
                    ParticleSystem newArcaneParticle = Instantiate(arcaneParticle);
                    newArcaneParticle.transform.position = gameObject.transform.position;
                    break;
                default:
                    break;
            }
        }
    }

    void WinScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LossScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
