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
}
