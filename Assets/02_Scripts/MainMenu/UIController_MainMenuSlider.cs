using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController_MainMenuSlider : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    private Slider _MusicSlider;
    private Slider _SFXSlider;

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
        _MusicSlider = _root.Q<Slider>("MusicSlider");
        _MusicSlider.RegisterValueChangedCallback(OnMusicVolumeChanged);

        _SFXSlider = _root.Q<Slider>("SFXSlider");
        _SFXSlider.RegisterValueChangedCallback(OnSFXVolumeChanged);
    }

    private void OnMusicVolumeChanged(ChangeEvent<float> evt)
    {
        float volume = evt.newValue;
        //Debug.Log("New Volume: " + volume);
        AudioManager.instance.MusicVolume(volume);
    }

    private void OnSFXVolumeChanged(ChangeEvent<float> evt)
    {
        float volume = evt.newValue;
        //Debug.Log("New Volume: " + volume);
        AudioManager.instance.SFXVolume(volume);
    }

}
