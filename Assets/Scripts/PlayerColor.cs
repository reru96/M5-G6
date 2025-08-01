using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{

    public TimeManager timerManager;
    public float delay = 2f;
    private bool isCounting = false;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
          if (Input.GetKeyDown(KeyCode.F) && !isCounting)
          {
                StartCoroutine(StartCountdownOnce());
          }
        
    }
    IEnumerator StartCountdownOnce()
    {
        isCounting = true;


        yield return StartCoroutine(timerManager.Countdown(delay, ChangeColor));

        isCounting = false;
    }
    void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        rend.material.color = randomColor;
    }
}
