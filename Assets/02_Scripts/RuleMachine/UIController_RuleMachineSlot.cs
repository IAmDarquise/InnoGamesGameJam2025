using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController_RuleMachineSlot : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    //[SerializeField] private int _spinSpeed;
    [SerializeField] private float _spinDuration;
    [SerializeField] private int _timesToSpin;
    private int _totalRotationDegrees;

    [SerializeField] private bool _isRotating;

    private Label _ruleName;


    private void Awake()
    {
        _totalRotationDegrees = _timesToSpin * 360;

        _root = _uiDoc.rootVisualElement;
    }

    private void Start()
    {
        _ruleName = _root.Q<Label>("RuleName");
    }



    public void Spin(RuleInfo rule)
    {

        if(_isRotating)
        {
            return;
        }

        _isRotating = true;

        _ruleName.text = rule.ruleName;

        Vector3 newVector = new Vector3(_totalRotationDegrees, 0, 0);
        transform.DOLocalRotate(newVector, _spinDuration, RotateMode.FastBeyond360);

        _isRotating = false;
        
    }



}
