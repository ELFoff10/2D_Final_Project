using FMODUnity;
using UnityEngine;

public class FMOD_Events : MonoBehaviour
{
    [field: SerializeField] public EventReference UiButtonPress {  get; private set; }
    
    [field: SerializeField] public EventReference BackgroundMusic {  get; private set; }

    public static FMOD_Events Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null) 
        {
            Debug.Log("Found double FMOD_Events on the scene");
        }

        Instance = this;
    }
}
