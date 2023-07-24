using UnityEngine;
using VContainer;

public class GameInstance : MonoBehaviour
{
    [Inject]
    private readonly IMultiSceneManager _multiSceneManager;

    [Inject]
    private readonly ScenesControllerModel _scenesControllerModel;

    private void Start()
    {
        //_multiSceneManager.LoadScene(ScenesStateEnum.Menu, NextSceneEndLoad);
    }
}