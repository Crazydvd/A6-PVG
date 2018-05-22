using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGod : MonoBehaviour
{
    public GameObject subtitle;
    public AudioClip voiceLine;

    public void ActivateVoice()
    {
        subtitle.SetActive(true);
        subtitle.GetComponent<AudioSource>().PlayOneShot(voiceLine);
        Destroy(subtitle, 15f);        
    }
}
