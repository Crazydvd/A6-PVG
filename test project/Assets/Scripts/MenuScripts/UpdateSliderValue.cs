using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderValue : MonoBehaviour {

    Text _volumeValue;

	// Use this for initialization
	void Start () {
        _volumeValue = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetValue(float volume)
    {
        _volumeValue.text = ((int)volume).ToString();
    }
}
