using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour {

    public float beatsPerMinute = 120;
    public float timeForBeat;
    public float timeScaleMinute = 60;
    public float timeScaleSecond = 1;

    public bool trigger;
    private float timer;

    private void Update()
    {
        float temp = beatsPerMinute / timeScaleMinute;
        timeForBeat = timeScaleSecond / temp;

        if (timeForBeat <= timer)
        {
            trigger = true;
            timer = 0;
            trigger = false;
        }
        else
        {
           timer += Time.deltaTime;
        }
    }
}
