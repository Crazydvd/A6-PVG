using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "death")
        {
            LevelManager.RestartLevel();
        }

        if (other.tag == "Finish")
        {
            LevelManager.NextLevel();
        }
    }
}