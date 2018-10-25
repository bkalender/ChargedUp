using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    public int CurrentScore;
    private int MaxUltScore = 100;
    private int ScorePerDestroy = 20;
    public bool UltReady;

    public Slider ultibar;

    private void Start()
    {
        CurrentScore = 0;
        ultibar.value = CalculateProgress();
    }

    private void Update()
    {
        if (UltReady){
            Debug.Log("Ult ready.");
        }

        if (Input.GetKeyDown(KeyCode.X)){
            AddScore();
        }
    }

    float CalculateProgress(){
        return CurrentScore  / MaxUltScore;
    }

    public void AddScore(){
        Debug.Log("+20 pts");
        if (CurrentScore < MaxUltScore){
            CurrentScore += ScorePerDestroy;
            ultibar.value = CalculateProgress();
        }
        else if (CurrentScore == MaxUltScore-ScorePerDestroy){
            CurrentScore = MaxUltScore;
            UltReady = true;
            ultibar.value = CalculateProgress();
        }
    }

}
