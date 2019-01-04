using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChargedUp.Settings;
namespace UI
{
    /*
    public class ScoreHandler : MonoBehaviour
    {

        public float CurrentScore;
        private float MaxUltScore = 100f;
        private float ScorePerDestroy = 20f;
        public bool UltReady;

        public Slider ultibar;
        public Image Fill;

        // Colors
        public Color MinFire = new Color(255, 221, 0); //FFDD00
        public Color MaxFire = new Color(255, 85, 0); //FF5500

        public Color MinFrost = new Color(167, 223, 214); //A7DFD6
        public Color MaxFrost = new Color(120, 200, 199); //78C8C7

        public Color MinArcane = new Color(180, 49, 244); //B431F4
        public Color MaxArcane = new Color(96, 24, 72); //601848

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (UltReady)
            {
                Debug.Log("Ult ready.");
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                AddScore();
            }
        }

        float CalculateProgress()
        {
            return CurrentScore / MaxUltScore;
        }

        private void Init()
        {
            CurrentScore = 0f;
            ultibar.minValue = 0f;
            ultibar.maxValue = MaxUltScore;
            ultibar.value = 0f;

            if (GlobalAttributes.PlayerMage == MageType.FireMage)
            {
                Fill.color = Color.Lerp(MinFire, MaxFire, CalculateProgress());
            }

        }

        public void AddScore()
        {
            Debug.Log("+20 pts");
            if (CurrentScore < MaxUltScore)
            {
                CurrentScore += ScorePerDestroy;
                ultibar.value = CalculateProgress();
            }
            else if (CurrentScore == MaxUltScore - ScorePerDestroy)
            {
                CurrentScore = MaxUltScore;
                UltReady = true;
                ultibar.value = CalculateProgress();
            }
        }

    }
*/
}
/*
    public int MaxHealth = 500;
    public Image Fill;  // assign in the editor the "Fill"


private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        counter = MaxHealth;            // just for testing purposes
    }

    private void Start()
    {
        slider.wholeNumbers = true;        // I dont want 3.543 Health but 3 or 4
        slider.minValue = 0f;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;        // start with full health
    }

    private void Update()
    {
        UpdateHealthBar(counter);        // just for testing purposes
        counter--;                        // just for testing purposes
    }

    public void UpdateHealthBar(int val)
    {
        slider.value = val;
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)val / MaxHealth);
    }
    */