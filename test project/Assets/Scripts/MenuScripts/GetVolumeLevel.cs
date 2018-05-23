using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GetVolumeLevel : MonoBehaviour {
    private Slider _slider;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _groupName;

	// Use this for initialization
	void Start () {
        _slider = GetComponent<Slider>();
        float vol;
        if (_mixer.GetFloat(_groupName, out vol))
            _slider.value = 100 - (100f / -80f * (int)vol);
    }
}
