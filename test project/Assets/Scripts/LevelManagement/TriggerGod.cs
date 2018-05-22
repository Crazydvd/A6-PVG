using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGod : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")        
            GetComponent<ActivateGod>().ActivateVoice();
        Destroy(this, 0f);
    }
}
