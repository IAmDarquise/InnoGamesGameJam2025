using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController_PauseMenu : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    [SerializeField] UIController_HUD _hud;

    private VisualElement _resumeButton;
    private VisualElement _exitButton;

    private bool isGamePaused = false;

    private void Awake()
    {
        _root = _uiDoc.rootVisualElement;
        RegisterCallbacks();

    }
    private void Start()
    {
        _root.style.visibility = Visibility.Hidden;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }

    private void RegisterCallbacks()
    {
        _resumeButton = _root.Q<VisualElement>("ResumeButton");
        _resumeButton.RegisterCallback<ClickEvent>(OnResumeButtonClicked);

        _exitButton = _root.Q<VisualElement>("ExitSimulation");
        _exitButton.RegisterCallback<ClickEvent>(OnExitButtonClicked);
    }

    private void OnResumeButtonClicked(ClickEvent eventArgs)
    {
        ContinueGame();
    }

    private void OnExitButtonClicked(ClickEvent eventArgs)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ContinueGame()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isGamePaused = false;
        _root.style.visibility = Visibility.Hidden;
        _hud.DisplayHUD(true);
    }

    private void PauseGame()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isGamePaused = true;
        _root.style.visibility = Visibility.Visible;
        _hud.DisplayHUD(false);
    }
}
