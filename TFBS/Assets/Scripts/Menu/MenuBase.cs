using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public abstract class MenuBase : BaseComponent
{
    public static bool IsPaused;

    protected bool toggleTime = true;

    Canvas Canvas;

    static readonly Stack<MenuBase> active = new Stack<MenuBase>();

    protected virtual void Awake()
    {
        Canvas = GetComponent<Canvas>();

        OnHideLast();
    }

    protected void OnDestroy()
    {
        active.Clear();
    }

    public void Toggle()
    {
        if (!Canvas.enabled)
            Show();
        else
            Hide();
    }

    protected virtual void Show()
    {
        if (active.Count == 0)
            OnShowFirst();
        else
            active.Peek().Canvas.enabled = false;

        Canvas.enabled = true;
        active.Push(this);
    }

    protected virtual void Hide()
    {
        active.Pop();
        Canvas.enabled = false;

        if (active.Count == 0)
            OnHideLast();
        else
            active.Peek().Canvas.enabled = true;
    }

    protected static void HideAll()
    {
        while (active.Count != 0)
            active.Pop().Hide();
    }

    void ToggleBlur(bool value)
    {
        for (int i = 0; i < Camera.allCamerasCount; i++)
        {
            BlurOptimized blurEffect = Camera.allCameras[i].GetComponent<BlurOptimized>();

            if (blurEffect == null)
                blurEffect = Camera.allCameras[i].gameObject.AddComponent<BlurOptimized>();

            blurEffect.enabled = value;
        }
    }

    protected void OnShowFirst()
    {
        if (toggleTime)
            Time.timeScale = 0;

        ToggleBlur(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    protected void OnHideLast()
    {
        ToggleBlur(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (toggleTime)
            Time.timeScale = 1;
    }
}
