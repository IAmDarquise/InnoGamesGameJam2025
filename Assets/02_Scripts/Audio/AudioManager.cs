using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
        [Header("Current Volume")]
#if UNITY_EDITOR
    [SerializeField, ViewOnly] private float currentMasterVolume;
    [SerializeField, ViewOnly] private float currentMusicVolume;
    [SerializeField, ViewOnly] private float currentSFXVolume;
#else
    private float currentMasterVolume;
    private float currentSFXVolume;
    private float currentMusicVolume;
#endif

    [Header("Start Volume")]
        [Range(0, 1)]
        [SerializeField] private float startMasterVolume;
        [Range(0, 1)]
        [SerializeField] private float startMusicVolume;
        [Range(0, 1)]
        [SerializeField] private float startSFXVolume;

        private Bus _masterBus;
        private Bus _musicBus;
        private Bus _sfxBus;

        private List<EventInstance> eventInstances;
        public static AudioManager instance { get; private set; }

        private EventInstance loopMusicEventInstance;

        private EventReference currentMusicReference;


    [SerializeField] private AllSettings _allSettings;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("found more than one Audio Manager in the scene");
            return;
        }
        instance = this;

        eventInstances = new List<EventInstance>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(FMOD_EventList.instance.mainMenu);
        _masterBus = RuntimeManager.GetBus("bus:/");
        _musicBus = RuntimeManager.GetBus("bus:/Music");
        _sfxBus = RuntimeManager.GetBus("bus:/SFX");


        MasterVolume(_allSettings.masterVolume);
        MusicVolume(_allSettings.musicVolume);
        SFXVolume(_allSettings.sfxVolume);
    }

    public void MasterVolume(float volume)
    {
        currentMasterVolume = volume;
        _masterBus.setVolume(volume);
        //_allSettings.masterVolume = volume;
        //GameManager.instance.SaveSettings();
    }

    public void MusicVolume(float volume)
    {
        currentMusicVolume = volume;
        _musicBus.setVolume((volume));
        //_allSettings.musicVolume = volume;
        //GameManager.instance.SaveSettings();

    }

    public void SFXVolume(float volume)
    {
        currentSFXVolume = volume;
        _sfxBus.setVolume((volume));
        //_allSettings.sfxVolume = volume;
        //GameManager.instance.SaveSettings();
    }

    public float GetMasterVolume()
    {
        return currentMasterVolume;
    }

    public float GetMusicVolume()
    {
        return currentMusicVolume;
    }

    public float GetSFXVolume()
    {
        return currentSFXVolume;
    }

    public float GetStandardMasterVolume()
    {
        return startMasterVolume;
    }

    public float GetStandardMusicVolume()
    {
        return startMusicVolume;
    }

    public float GetStandardSFXVolume()
    {
        return startSFXVolume;
    }

    public void Play3DOneShot(EventReference sound, Vector3 pos)
    {
            RuntimeManager.PlayOneShot(sound, pos);
    }

    public void Play2DOneShot(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound);
    }

    public void PlayMusic(EventReference musicEvent)
    {
        if (musicEvent.Equals(currentMusicReference))
            return;

        currentMusicReference = musicEvent;

        if (loopMusicEventInstance.isValid())
        {
            loopMusicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            loopMusicEventInstance.release();
        }

        loopMusicEventInstance = CreateInstance(musicEvent);
        loopMusicEventInstance.start();
    }

    public void StopMusic()
    {
        loopMusicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }
}


