using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Start")]
    public GameObject main;
    public GameObject gameTitle;
    public GameObject starttext;
    public GameObject menu;

    [Header("Custom")]
    public GameObject[] weaponPrefab;
    public GameObject weaponPool;
    public GameObject changeWeaponClose;
    public GameObject playerPosition;
    private GameObject currLeftWeapon;
    private GameObject currRightWeapon;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //if (clickStart == false)
        //{
        //    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        //    {
        //        goMenu();
        //        clickStart = true;
        //    }
        //}
    }

    private void Start()
    {
        StartCoroutine(BeforeStart(main, 1));
        StartCoroutine(BeforeStart(gameTitle, 3));
        StartCoroutine(BeforeStart(starttext, 4));

        currLeftWeapon = weaponPrefab[0];
        currLeftWeapon = weaponPrefab[4];
    }

    public void goMenu()
    {
        main.SetActive(false);
        menu.SetActive(true);
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator BeforeStart(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
    }
    public void OpenMenu(GameObject settingMenu)
    {
        settingMenu.SetActive(true);
    }

    public void CloseMenu(GameObject settingMenu)
    {
        settingMenu.SetActive(false);
    }

    public void ChangeWeapon()
    {
        CloseMenu(menu);
        weaponPool.SetActive(true);
        for (int i = 0; i < 21; i++)
            weaponPool.transform.position += Vector3.up;
        changeWeaponClose.SetActive(true);
    }
    public void CloseChangeWeapon()
    {
        for (int i = 0; i < 21; i++)
            weaponPool.transform.position -= Vector3.up;
        changeWeaponClose.SetActive(false);
        weaponPool.SetActive(false);
        OpenMenu(menu);
    }


    public void PlaySound(AudioClip clip)
    {
        // 오디오 재생 로직
    }
    // 게임 상태 관리
    public void StartGame()
    {
        // 게임 시작 로직
    }

    public void EndGame()
    {
        // 게임 종료 로직
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
