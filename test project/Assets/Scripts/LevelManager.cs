using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static int _levelNumber;
    private static int _sceneCount;
    private static int _next;

    private void Start()
    {
        _levelNumber = SceneManager.GetActiveScene().buildIndex;
        _sceneCount = SceneManager.sceneCountInBuildSettings;

        _next = _levelNumber + 1;
        if (_next >= _sceneCount)
        {
            _next = 0;
        }
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(_next, LoadSceneMode.Single);
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}