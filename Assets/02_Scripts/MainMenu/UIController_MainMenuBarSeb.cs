using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController_MainMenuBarSeb : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    private VisualElement _barSeb;

    private void Awake()
    {
        _root = _uiDoc.rootVisualElement;
        RegisterCallbacks();

    }

    private void RegisterCallbacks()
    {
        _barSeb = _root.Q<VisualElement>("Parent");
        _barSeb.RegisterCallback<ClickEvent>(OnBarSebClicked);
    }

    private void OnBarSebClicked(ClickEvent eventArgs)
    {
        AudioManager.instance.Play2DOneShot(FMOD_EventList.instance.barSeb);
    }

}
