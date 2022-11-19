using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FullMessageView : MonoBehaviour
{
    [SerializeField] private Image _messageImage;
    [SerializeField] private TMP_Text _messageText;
    [SerializeField] private RectTransform _rectTransform;

    [Inject] private Player _player;
    [Inject] private SizeUpgradeButton _sizeUpgrade;

    private void OnEnable()
    {
        _player.PlayerFull += OnPlayerFull;
        _player.PlayerNotFullMore += OnPlayerNotFullMore;
        _sizeUpgrade.SizeIncreased += OnSizeIncreased;
    }

    private void OnDisable()
    {
        _player.PlayerFull -= OnPlayerFull;
        _player.PlayerNotFullMore -= OnPlayerNotFullMore;
        _sizeUpgrade.SizeIncreased -= OnSizeIncreased;
    }

    private void OnPlayerFull()
    {
        _messageImage.enabled = true;
        _messageText.enabled = true;
    }

    private void OnPlayerNotFullMore()
    {
        _messageImage.enabled = false;
        _messageText.enabled = false;
    }

    private void OnSizeIncreased(float deltaHeight)
    {
        _rectTransform.anchoredPosition = new Vector2(_rectTransform.localPosition.x, _rectTransform.localPosition.y + deltaHeight);
    }
}
