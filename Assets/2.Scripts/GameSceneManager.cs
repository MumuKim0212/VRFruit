using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject menu;
    public void OpenMenu()
    {
        GameManager.Instance.OpenMenu(menu);
    }
}
