using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIBounceInEffect menuPanel;
    public UIBlurEffect blurEffect;

    public void OpenMenu()
    {
        menuPanel.gameObject.SetActive(true);
        menuPanel.PlayBounceInAnimation();
    }

    public void CloseMenu()
    {
        menuPanel.PlayBounceOutAnimation(() =>
        {
            menuPanel.gameObject.SetActive(false);
        });
    }
    public void UpdateBlur()
    {
        blurEffect.ApplyBlur();
    }
}