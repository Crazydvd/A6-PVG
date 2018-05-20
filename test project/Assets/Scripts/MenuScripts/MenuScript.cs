using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void CloseGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}