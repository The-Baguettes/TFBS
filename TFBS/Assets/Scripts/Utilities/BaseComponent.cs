using UnityEngine;

public abstract class BaseComponent : MonoBehaviour
{
    public delegate void EventHandler();

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
    }

    protected void OnDestroy()
    {
        UnHookEvents();
    }
}
