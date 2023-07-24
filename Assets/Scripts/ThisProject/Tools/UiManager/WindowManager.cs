using UniRx;
using UnityEngine;
using VContainer;
using Debug = UnityEngine.Debug;

public class WindowManager : MonoBehaviour, IWindowManager
{
    [SerializeField]
    private Canvas _menuCanvas;

    [SerializeField]
    private Transform _nonActiveParent;

    private AssetBundle _assetBundle;
    private IWindowFinder _finder;

    private WindowStack _stack;
    public Canvas MenuCanvas => _menuCanvas;
    public ReadOnlyReactiveProperty<Window> LastWindow => _stack.LastWindow;

    [Inject]
    private readonly UiFabric _uiFabric;

    private void Awake()
    {
        Debug.Log("Awake");

        _finder = new WindowFinder(_nonActiveParent, _uiFabric);
        _stack = new WindowStack(_menuCanvas.transform, _nonActiveParent);
    }

    public void ClearStack()
    {
        Debug.Log("Clearing stack");
        WindowStack stack = _stack;

        stack.Clear();

        foreach (var window in _nonActiveParent.GetComponentsInChildren<Window>(true))
            if (!window.IsUndestroyable)
                _finder.UnloadWindow(window);
    }

    public T FindWindow<T>() where T : Window
    {
        T window = _finder.FindWindow<T>();
        return window;
    }

    public T GetWindow<T>() where T : Window
    {
        T window = _finder.GetWindow<T>();
        window.Setup(this);
        return window;
    }

    public void First(Window window) => First(window, window.Priority);

    public void First(Window window, WindowPriority priority)
    {
        Debug.Log($"First window in stack '{window.Name}'");
        window.Priority = priority;
        _stack.First(window);
    }

    public void Show(Window window) => Show(window, window.Priority);

    public void Show(Window window, WindowPriority priority)
    {
        string wn = window.Name;
        Debug.Log($"Show window: '{wn}' with priority: '{priority}'");
        if (window.IsShowing)
        {
            Debug.LogWarning($"Window '{wn}' is already showing");
            return;
        }

        window.Priority = priority;

        _stack.Add(window);

        var canvas = window.GetComponent<Canvas>();
        if (canvas != null)
            canvas.overrideSorting = false;

        window.Show();
    }

    public void Hide(Window window)
    {
        if (window == null) return;

        Debug.Log($"Hide window '{window.Name}'");
        if (!window.IsShowing)
        {
            Debug.LogWarning($"Window '{window.Name}' is already hidden");
            return;
        }

        _stack.Remove(window);
        window.Hide();
    }

    public T Show<T>(WindowPriority? priority = null) where T : Window
    {
        T window = GetWindow<T>();
        Show(window, priority ?? window.Priority);
        return window;
    }

    public T First<T>(WindowPriority? priority = null) where T : Window
    {
        T window = GetWindow<T>();
        First(window, priority ?? window.Priority);
        return window;
    }

    public T Hide<T>() where T : Window
    {
        T window = GetWindow<T>();
        Hide(window);
        return window;
    }
}