using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGod : MonoBehaviour
{
    public GameObject subtitle;
    public AudioClip voiceLine;

    public void ActivateVoice()
    {
        for(int i = 0; i < subtitle.transform.parent.childCount; i++) {
            //subtitle.transform.parent.GetChild(i).gameObject.SetActive(false);
        }

        subtitle.SetActive(true);
        subtitle.GetComponent<AudioSource>().PlayOneShot(voiceLine);
        Destroy(subtitle, 20f);        
    }
}
