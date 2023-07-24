using System;
using UniRx;

public class ScenesControllerModel
{
    private ScenesStateEnum _scene = ScenesStateEnum.Menu;
    private readonly IMultiSceneManager _multiSceneManager;
    private readonly ICoreStateMachine _coreStateMachine;
    private readonly IWindowManager _windowManager;

    public ScenesControllerModel(IMultiSceneManager multiSceneManager, ICoreStateMachine coreStateMachine,
        IWindowManager windowManager)
    {
        _multiSceneManager = multiSceneManager;
        _coreStateMachine = coreStateMachine;
        _windowManager = windowManager;
    }

    public void Init()
    {
        _coreStateMachine.ScenesState.Subscribe(CurrentSceneSwitches);
        _windowManager.Show<FadeSceneWindow>(WindowPriority.LoadScene);
        EndCloseFade();
    }

    private void CurrentSceneSwitches(ScenesStateEnum scene)
    {
        _windowManager.Show<FadeSceneWindow>(WindowPriority.LoadScene).CloseFade(EndCloseFade);
        _scene = scene;
    }

    private void EndCloseFade()
    {
        switch (_scene)
        {
            case ScenesStateEnum.Menu:
                _multiSceneManager.LoadScene(_scene, NextSceneEndLoad);
                break;
            case ScenesStateEnum.Base:
                break;
            case ScenesStateEnum.Level_1:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void EndOpenFade()
    {
        _coreStateMachine.OnSceneEndLoadFade();
    }

    private void NextSceneEndLoad()
    {
        _multiSceneManager.UnloadLastScene();
        _multiSceneManager.SetActiveLastLoadScene();
        _windowManager.Show<FadeSceneWindow>().OpenFade(EndOpenFade);
    }
}