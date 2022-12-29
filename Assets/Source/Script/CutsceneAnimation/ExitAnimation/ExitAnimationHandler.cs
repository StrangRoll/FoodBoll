using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ExitAnimationHandler : MonoBehaviour
{
    [SerializeField] private ExitController _exitController;

    [Inject] private StartAnimationHandler _startAnimation;

    private List<IExitAnimationWaiter> _exitAnimationWaiters = new List<IExitAnimationWaiter>();

    public bool IsGoing { get; private set; } = false;

    private void OnEnable()
    {
        _exitController.SphereEntered += OnSphereEntered;
        _exitController.SphereExited += OnSphereExited;
    }

    private void OnDisable()
    {
        _exitController.SphereEntered -= OnSphereEntered;
        _exitController.SphereExited -= OnSphereExited;
    }

    public void Register(IExitAnimationWaiter animationWaiter)
    {
        _exitAnimationWaiters.Add(animationWaiter);
    }
    public void UnRegister(IExitAnimationWaiter animationWaiter)
    {
        _exitAnimationWaiters.Remove(animationWaiter);
    }

    public void OnStartAnimation(bool isGoing)
    {
        IsGoing = isGoing;

        foreach (var animationWaiter in _exitAnimationWaiters)
        {
            animationWaiter.OnExitAnimation(isGoing);
        }
    }

    private void OnSphereExited()
    {
        if (IsGoing == true && _startAnimation.IsGoing == false)
        {
            OnStartAnimation(false);
        }
    }

    private void OnSphereEntered()
    {
        if (IsGoing == false && _startAnimation.IsGoing == false)
        {
            OnStartAnimation(true);
        }
    }
}
