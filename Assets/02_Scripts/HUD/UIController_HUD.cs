using UnityEngine;
using UnityEngine.UIElements;

public class UIController_HUD : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    private ProgressBar _playerHealth;

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
    }

    public void DisplayPlayerHeath(float health)
    {
        _playerHealth.value = health;
    }
}
