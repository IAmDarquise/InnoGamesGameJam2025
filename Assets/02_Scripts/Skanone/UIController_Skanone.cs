using UnityEngine;
using UnityEngine.UIElements;

public class UIController_Skanone : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    private Label _label;

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
        _label = _root.Q<Label>("Label");

    }

    public void DisplayAmmo(int amount)
    {
        if(amount > 999)
        {
            return;
        }

        _label.text = amount.ToString();
    }
}
