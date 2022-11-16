using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonsActivator : MonoBehaviour
{
    [SerializeField] private CanvasGroup _buttonGroup;
    [SerializeField] private UpgradePlatfom _upgrader;

    private void OnEnable()
    {
        _upgrader.PlayerEntered += OnPlayerEntered;
        _upgrader.PlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        _upgrader.PlayerEntered -= OnPlayerEntered;
        _upgrader.PlayerLeft -= OnPlayerLeft;
    }

    private void OnPlayerEntered()
    {
        _buttonGroup.alpha = 1;
        _buttonGroup.blocksRaycasts = true;
        _buttonGroup.interactable = true;
    }

    private void OnPlayerLeft()
    {
        _buttonGroup.alpha = 0;
        _buttonGroup.blocksRaycasts = false;
        _buttonGroup.interactable = false;
    }
}
