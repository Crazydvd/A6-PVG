using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _levelNumber;
    private int _sceneCount;
    private int _next;
    private static int _checkPointNumber = -1;

    [Tooltip("The player")]
    public GameObject Player;

    [Tooltip("All the checkpoints in the level")]
    public List<GameObject> CheckPoints = new List<GameObject>();

    [Tooltip("Optionally: the next level to load (buildIndex)\n(leave at -1 to go to next level by default)")]
    public int Next = -1;

    private void Start()
    {
        _levelNumber = SceneManager.GetActiveScene().buildIndex;
        _sceneCount = SceneManager.sceneCountInBuildSettings;

        if (Next > -1)
        {
            _next = _levelNumber + 1;
        }
        else
        {
            _next = Next;
        }

        if (_next >= _sceneCount)
        {
            _next = 0;
        }

        for (int i = 0; i < CheckPoints.Count; i++)
        {
            CheckPoints[i].GetComponent<CheckPoint>().CheckPointNumber = i;
        }

        if (_checkPointNumber > -1)
        {
            Player.transform.position = CheckPoints[_checkPointNumber].transform.position;
        }
    }

    public static void ReachCheckPoint(int pCheckPointNumber)
    {
        _checkPointNumber = pCheckPointNumber;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_next, LoadSceneMode.Single);
        _checkPointNumber = -1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}