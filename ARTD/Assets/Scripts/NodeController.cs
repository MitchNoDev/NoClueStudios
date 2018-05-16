using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class NodeController : MonoBehaviour {

    public bool buffNode;
    public bool towerOn;
    public bool trigger;

    [Header("Buffs")]
    public int damage;
    public int turningSpeed;
    public int bulletSpeed;
    public int enemySlow;

    [Header("Audio Stuff")]
    public bool noteNode;
    public string noteType;
    public AudioMixer mixer;

	// Use this for initialization
	void Start ()
    {
        trigger = true;
        towerOn = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (trigger)
        {
            if (towerOn)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

                if (noteNode)
                {
                    mixer.SetFloat(noteType, 1f);
                }

                trigger = false;
            }
            else if (!towerOn)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                trigger = false;
            }
        }
	}
}
