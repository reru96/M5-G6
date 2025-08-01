using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float timeLeft = 60f;
    [SerializeField] private TextMeshProUGUI timerText;

    public IEnumerator Countdown(float seconds, Action callback)
    {
        timeLeft = seconds;
        
        while (timeLeft > 0)
        {
                timerText.text = Mathf.Round(timeLeft).ToString();
                yield return new WaitForSeconds(1f);
                timeLeft--;
        }
        
        timerText.text = "0";
        callback?.Invoke();
    }
    
   
}
