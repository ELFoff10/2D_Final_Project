using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FadeSceneWindow : Window
{
    [SerializeField]
    private Animator _animator;

    private Action _fadeSceneDelegate;

    protected override void OnDeactivate()
    {
        base.OnDeactivate();
        _fadeSceneDelegate = null;
    }

    public void OpenFade(Action endBack)
    {
        _animator.SetTrigger(StringsStatic.Helper.Open);
        _fadeSceneDelegate = endBack;
    }

    public void CloseFade(Action endBack)
    {
        _animator.SetTrigger(StringsStatic.Helper.Close);
        _fadeSceneDelegate = endBack;
    }

    public void EndOpenFade()
    {
        _fadeSceneDelegate?.Invoke();
        Debug.Log("Open scene Fade ended");
        _manager.Hide(this);
    }

    public void EndCloseFade()
    {
        _fadeSceneDelegate?.Invoke();
        Debug.Log("Close scene Fade ended");
    }
}