using DG.Tweening;
using UnityEngine;

public class UIController_RuleMachineSlot : MonoBehaviour
{

    //[SerializeField] private int _spinSpeed;
    [SerializeField] private float _spinDuration;
    [SerializeField] private int _timesToSpin;
    private int _totalRotationDegrees;

    [SerializeField] private bool _isRotating;


    private void Awake()
    {
        _totalRotationDegrees = _timesToSpin * 360;    
    }

    //private void Start()
    //{
    //    Spin();
    //}



    public void Spin()
    {
        if(_isRotating)
        {
            return;
        }

        _isRotating = true;

        Vector3 newVector = new Vector3(_totalRotationDegrees, 0, 0);
        transform.DORotate(newVector, _spinDuration, RotateMode.FastBeyond360);

        _isRotating = false;
        
    }



}
