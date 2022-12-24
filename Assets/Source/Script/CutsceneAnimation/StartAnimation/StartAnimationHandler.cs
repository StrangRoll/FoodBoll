using System.Collections.Generic;
using UnityEngine;

public class StartAnimationHandler : MonoBehaviour, IStartAnimationWaiter
{
    [SerializeField] private ExitController _exitController;

    private List<IStartAnimationWaiter> _startAnimationWaiters = new List<IStartAnimationWaiter>();

    public bool IsGoing { get; private set; } = true;

    private void OnEnable()
    {
        _exitController.SphereExited += OnSphereExited;
    }

    private void OnDisable()
    {
        _exitController.SphereExited -= OnSphereExited;
    }

    public void Register(IStartAnimationWaiter animationWaiter)
    {
        _startAnimationWaiters.Add(animationWaiter);
    }
    public void UnRegister(IStartAnimationWaiter animationWaiter)
    {
        _startAnimationWaiters.Remove(animationWaiter);
    }

    public void OnStartAnimation(bool isGoing)
    {
        IsGoing = isGoing;

        foreach (var animationWaiter in _startAnimationWaiters)
        {
            animationWaiter.OnStartAnimation(isGoing);
        }
    }

    private void OnSphereExited()
    {
        if (IsGoing)
        {
            OnStartAnimation(false);
        }
    }
}
