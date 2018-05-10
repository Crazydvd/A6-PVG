using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltIce : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ice")
        {
            IceMelt melt =  collision.gameObject.GetComponent<IceMelt>();
            melt.AutoMelt = true;
            melt.MeltTime *= 0.1f;
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}