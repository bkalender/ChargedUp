using System;
using ChargedUp.Settings;
using UnityEngine;
using UnityEngine.UI;

public class AiPlayer : MonoBehaviour {

    public Color MaxFire = new Color(255, 85, 0); //FF5500
    public Color MaxFrost = new Color(120, 200, 199); //78C8C7
    public Color MaxArcane = new Color(96, 24, 72); //601848

    public Image Fill;
    public static MageType mageType;
    public static float aiScore;
    public static Text aiScoreField;
    public AiPlayer(MageType type)
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

    }
    public static Text getAiScoreField()
    {
        return aiScoreField;
    }
        
    public static float getAIScore(){
        return aiScore;
    }
    void Start()
    {
        aiScore = 0f;
        mageType = GlobalAttributes.PlayerMage;
        aiScoreField = FindObjectsOfType<Text>()[0];

    }
}

