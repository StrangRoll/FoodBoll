using DG.Tweening;
using NTC.Global.Pool;
using UnityEngine;

public class MoneyPlus : MonoBehaviour, IPoolItem
{
    [SerializeField] private float _deltaY;
    [SerializeField] private float _duration;

    private Vector3 _startPosition;
    private RectTransform _rect;

    private void Awake()
    {
        _startPosition = transform.position;
        _rect = GetComponent<RectTransform>();
    }

    public void OnDespawn()
    {
        transform.position = _startPosition;
    }

    public void OnSpawn()
    {
        _rect.DOAnchorPosY(_deltaY, _duration).OnComplete(OnAnimationEnded);
    }

    private void OnAnimationEnded()
    {
        NightPool.Despawn(this);
    }
}
