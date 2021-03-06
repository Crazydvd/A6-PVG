﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Melt ice
        if (collision.gameObject.tag == "ice")
        {
            IceMelt melt = collision.gameObject.GetComponent<IceMelt>();
            melt.AutoMelt = true;
            melt.MeltTime *= 0.1f;
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

        // Light Brazier
        if (collision.gameObject.tag == "brazier")
        {
            collision.gameObject.GetComponent<Brazier>().Light();
        }

        // Burn Wood
        if(collision.gameObject.tag == "Wood")
        {
            collision.gameObject.GetComponent<WoodScript>().Burn();
        }
    }
}
