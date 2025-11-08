using DG.Tweening;
using UnityEngine;

public class RuleMachineParent : MonoBehaviour
{

    [SerializeField] private float _floatDistance = 0.5f;
    [SerializeField] private float _floatDuration = 1f;

    private void Start()
    {

        transform.DOLocalMoveY(transform.position.y + _floatDistance, _floatDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutFlash);
    }

    //void LateUpdate()
    //{
    //    Camera cam = Camera.main;
    //    if (cam == null)
    //    {
    //        return;
    //    }

    //    Vector3 direction = cam.transform.position - transform.position;
    //    direction.y = 0f;

    //    if (direction.sqrMagnitude > 0.001f)
    //    {
    //        Quaternion lookRotation = Quaternion.LookRotation(direction);
    //        transform.rotation = lookRotation;
    //    }
    //}
}
