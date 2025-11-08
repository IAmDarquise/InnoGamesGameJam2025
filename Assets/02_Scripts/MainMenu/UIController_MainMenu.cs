using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController_MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    private VisualElement _startButton;
    private VisualElement _exitButton;

    private void Awake()
    {
        _root = _uiDoc.rootVisualElement;

    }
    private void Start()
    {
        RegisterCallbacks();
    }

    private void RegisterCallbacks()
    {
        _startButton = _root.Q<VisualElement>("Start");
        _startButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);

        _exitButton = _root.Q<VisualElement>("Exit");
        _exitButton.RegisterCallback<ClickEvent>(OnExitButtonClicked);
    }

    private void OnStartButtonClicked(ClickEvent eventArgs)
    {
        Debug.Log("Start");
        SceneManager.LoadScene("MainScene");
    }

    private void OnExitButtonClicked(ClickEvent eventArgs)
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
