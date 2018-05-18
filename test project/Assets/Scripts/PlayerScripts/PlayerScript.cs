using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [Tooltip("The levelManager")]
    public GameObject Manager;

    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = Manager.GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "death" || other.tag == "PlayerDeath")
        {
            _levelManager.RestartLevel();
        }

        if (other.tag == "Finish")
        {
            _levelManager.NextLevel();
        }
    }
}