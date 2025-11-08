using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private AllSettings allSettings;

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private static readonly string SETTINGS_FILE = "settings.json";

    public void Init()
    {
        if(!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    
    public void SaveSettings()
    {
        string settingsJson = JsonUtility.ToJson(allSettings, true);
        File.WriteAllText(SAVE_FOLDER + SETTINGS_FILE, settingsJson);
    }

    public bool DoesSettingsFileExist()
    {
        if(File.Exists(SAVE_FOLDER + SETTINGS_FILE))
        {
            return true;
        }
        return false;
    }

    public void LoadSettings()
    { 
        if(File.Exists(SAVE_FOLDER + SETTINGS_FILE))
        {
            string settingsJson = File.ReadAllText(SAVE_FOLDER + SETTINGS_FILE);
            JsonUtility.FromJsonOverwrite(settingsJson, allSettings);

            AudioManager.instance.MasterVolume(allSettings.masterVolume);
            AudioManager.instance.MusicVolume(allSettings.musicVolume);
            AudioManager.instance.SFXVolume(allSettings.sfxVolume);

        }
        else
        {
            SaveStandardValues();
        }
    }

    private void SaveStandardValues()
    {
        allSettings.masterVolume = AudioManager.instance.GetStandardMasterVolume();
        allSettings.musicVolume = AudioManager.instance.GetStandardMusicVolume();
        allSettings.sfxVolume = AudioManager.instance.GetStandardSFXVolume();

        SaveSettings();
        LoadSettings();
    }
}
