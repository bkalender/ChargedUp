using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ChargedUp.Settings;
using Core;


public class MainMenu : MonoBehaviour {

    public float DifEasy = 5.0f;
    public float DifMed = 3.0f;
    public float DifHard = 2.0f;

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlayFireMage(){
        //GlobalAttributes.setPlayerMage(MageType.FireMage);
        Player player = new Player(MageType.FireMage);
        PlayGame();
    }

    public void PlayFrostMage()
    {
        //GlobalAttributes.setPlayerMage(MageType.FrostMage);
        Player player = new Player(MageType.FrostMage);
        PlayGame();
    }

    public void PlayArcaneMage()
    {
        //GlobalAttributes.setPlayerMage(MageType.ArcaneMage);
        Player player = new Player(MageType.ArcaneMage);
        PlayGame();
    }

    public void SetDifficultyEasy(){
        GlobalAttributes.SetDifficulty(DifEasy);
    }

    public void SetDifficultyMedium()
    {
        GlobalAttributes.SetDifficulty(DifMed);
    }

    public void SetDifficultyHard()
    {
        GlobalAttributes.SetDifficulty(DifHard);
    }
}
