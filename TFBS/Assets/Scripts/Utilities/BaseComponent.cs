using UnityEngine;

public abstract class BaseComponent : MonoBehaviour
{
    public delegate void EventHandler();

    bool isInitialized;
    event EventHandler Initialized;

    #region OverridableMethods
    protected virtual void OnStart()
    { }

    protected virtual void HookUpEvents()
    { }
    protected virtual void UnHookEvents()
    { }
    #endregion

    protected void Start()
    {
        OnStart();
        HookUpEvents();

        isInitialized = true;

        if (Initialized != null)
        {
            Initialized();
            Initialized = null;
        }
    }

    protected void OnDestroy()
    {
        UnHookEvents();
    }

    public void OnInitialized(EventHandler handler)
    {
        if (isInitialized)
            handler();
        else
            Initialized += handler;
    }
}
