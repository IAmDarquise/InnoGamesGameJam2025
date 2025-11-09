using UnityEngine;
using UnityEngine.UIElements;

public class UIController_HUD : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    private ProgressBar _playerHealth;
    private Label _labelScore;
    private Label _labelWave;


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
        _playerHealth = _root.Q<ProgressBar>("HealthBar");
        _labelScore = _root.Q<Label>("ScoreAmount");
        _labelWave = _root.Q<Label>("WaveAmount");
    }

    public void DisplayPlayerHeath(float health)
    {
        _playerHealth.value = health;
    }

    public void DisplayScore(int score)
    {
        _labelScore.text = score.ToString();
    }

    public void DisplayWave(int wave)
    {
        _labelWave.text = wave.ToString();
    }
}
