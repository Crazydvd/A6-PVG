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

    private static bool _air;
    private static bool _water;
    private static bool _fire;
    private static ShootingScript _player;

    [Tooltip("The player")]
    public GameObject Player;

    [Tooltip("All the checkpoints in the level")]
    public List<GameObject> CheckPoints = new List<GameObject>();

    [Tooltip("Optionally: the next level to load (buildIndex)\n(leave at -1 to go to next level by default)")]
    public int Next = -1;


    private void Start()
    {
        Time.timeScale = 1;

        _levelNumber = SceneManager.GetActiveScene().buildIndex;
        _sceneCount = SceneManager.sceneCountInBuildSettings;
        if (Next > -1)
        {
            _next = Next;
        }
        else
        {
            _next = _levelNumber + 1;
        }

        if (_next >= _sceneCount)
        {
            _next = 0;
        }

        if (Player != null)
        {
            for (int i = 0; i < CheckPoints.Count; i++)
            {
                CheckPoints[i].GetComponent<CheckPoint>().CheckPointNumber = i;
            }

            _player = Player.gameObject.GetComponent<ShootingScript>();

            if (_checkPointNumber > -1)
            {
                _player.SetAir(_air);
                _player.SetWater(_water);
                _player.SetFire(_fire);

                if (_air)
                {
                    _player.SetAirEnabled(true);
                }

                Player.transform.position = CheckPoints[_checkPointNumber].transform.position;
            }
        }
    }

    public static void ReachCheckPoint(int pCheckPointNumber)
    {
        _checkPointNumber = pCheckPointNumber;
        _air = _player.Air();
        _water = _player.Water();
        _fire = _player.Fire();
    }

    public void NextLevel()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(_next, LoadSceneMode.Single);
        _checkPointNumber = -1;
        _air = false;
        _water = false;
        _fire = false;
    }

    public void NextLevel(int pLevelNumber)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(pLevelNumber, LoadSceneMode.Single);
        _checkPointNumber = -1;
        _air = false;
        _water = false;
        _fire = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(_levelNumber);
    }
}