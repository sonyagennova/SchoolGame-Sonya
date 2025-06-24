using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public TextMeshProUGUI life;
    public float lifeCnt = 0.0f;

    public void IncreaseLife(){
        lifeCnt += 1.0f;
        life.text = lifeCnt.ToString();
    }

    public void DecreaseLife(float decrease){
        lifeCnt -= decrease;
        if(lifeCnt < 0){
            lifeCnt = 0;
        }
        life.text = lifeCnt.ToString();
    }
}
