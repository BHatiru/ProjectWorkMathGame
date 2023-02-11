using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] public TextMeshProUGUI textTimer;
    [SerializeField] private char characterSplitter = ':';

    [Header("Logic")]
    private float timer;
    private bool isActive;
    public Text timestat;

    public void Start()//start timer when scene loaded
    {
        isActive = true;
        timer = 0;
        UpdateText();
    }
    public void Update() // shows and updates the timer
    {
        timestat.text = "Time: "+textTimer.text; 

        if (isActive)
        {
            timer += Time.deltaTime;
            UpdateText();
        }
    }
    public void UpdateText()
    {
        float seconds = (timer % 60);
        float minutes = ((int)(timer / 60) % 60);

        textTimer.text = minutes.ToString("00") + characterSplitter
            + seconds.ToString("00");
    }//for correct display of minutes and seconds in the timer
}
