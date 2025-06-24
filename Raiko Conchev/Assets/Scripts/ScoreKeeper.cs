using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public TextMeshProUGUI score;
    public int scoreCnt = 0;

    public ButtonChecker isCorrect;

    public void IncreaseScore(){
        
        scoreCnt ++;
        score.text = scoreCnt.ToString();
    }

    public void DecreaseScore(){
        scoreCnt --;
        if(scoreCnt < 0){
            scoreCnt = 0;
        }
        score.text = scoreCnt.ToString();
    }
}
