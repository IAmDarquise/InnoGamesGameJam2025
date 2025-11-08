using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public SaveSystem saveSystem;
    public static SettingsManager instance;

    public AllSettings _allSettings;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        saveSystem.Init();

    }

    private void Start()
    {
        LoadSettings();
    }

    public void SaveSettings()
    {
        saveSystem.SaveSettings();
    }

    public void LoadSettings()
    {
        saveSystem.LoadSettings();
    }

    public void DoSettingsExist()
    {
        saveSystem.DoesSettingsFileExist();
    }

}
