using System;
using ChargedUp.Settings;
using UnityEngine;
using UnityEngine.UI;
namespace Core
{
    public class Player : MonoBehaviour
    {

        public Color MaxFire = new Color(255, 85, 0); //FF5500
        public Color MaxFrost = new Color(120, 200, 199); //78C8C7
        public Color MaxArcane = new Color(96, 24, 72); //601848

        public Image Fill;
        public static Slider ultibar;
        public static bool UltReady;
        public static MageType mageType;
        public static float playerScore;
        public static Text scoreField;
        public Player(MageType type)
        {
            if (mageType.Equals(MageType.FireMage))
            {
                Fill.color = MaxFire;
            }
            else if (mageType.Equals(MageType.FrostMage))
            {
                Fill.color = MaxFrost;
            }
            else if (mageType.Equals(MageType.ArcaneMage))
            {
                Fill.color = MaxArcane;
            }
            UltReady = false;
            playerScore = 0f;
            mageType = type;
        }
        void Start(){
            ultibar = FindObjectOfType<Slider>();
            scoreField = FindObjectsOfType<Text>()[1];

        }
    }
}
