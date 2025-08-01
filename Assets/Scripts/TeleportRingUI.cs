using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TeleportRingUI : MonoBehaviour
{
    private float timeLeft = 60f;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider slider;

    public IEnumerator Countdown(float seconds, Action callback)
    {
        timeLeft = seconds;
        SetMaxAmount((int)timeLeft);

        while (timeLeft > 0)
        {
            timerText.text = Mathf.Round(timeLeft).ToString();
            SetCurrentAmount((int)timeLeft);
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        timerText.text = "0";
        SetCurrentAmount(0);
        callback?.Invoke();
    }

    public void SetMaxAmount(int maxAmount)
    {

        slider.maxValue = maxAmount;
        slider.value = maxAmount;

    }

    public void SetCurrentAmount(int currentAmount)
    {
        slider.value = currentAmount;

    }

}
