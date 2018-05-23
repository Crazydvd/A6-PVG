using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour {

    [SerializeField] private AudioMixer _audioMixer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMasterVolume(float volume)
    {
        _audioMixer.SetFloat("masterVol", -80 + (80f / 100f * (int)volume));
    }

    public void SetBackgroundVolume(float volume)
    {
        _audioMixer.SetFloat("backgroundVol", -80 + (80f / 100f * (int)volume));
    }

    public void SetEffectVolume(float volume)
    {
        _audioMixer.SetFloat("effectVol", -80 + (80f / 100f * (int)volume));
    }

    public void SetVoicesVolume(float volume)
    {
        _audioMixer.SetFloat("voicesVol", -80 + (((80f / 100f)) * (int)volume));
    }
}
