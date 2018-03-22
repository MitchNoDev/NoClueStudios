using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour {

    public int beatsPerMinute = 120;
    public float timeForBeat;
    public int timeScaleMinute = 60;
    public int timeScaleSecond = 1;

    private void Start()
    {
        float temp = beatsPerMinute / timeScaleMinute;
        timeForBeat = timeScaleSecond / temp;
    }
}
