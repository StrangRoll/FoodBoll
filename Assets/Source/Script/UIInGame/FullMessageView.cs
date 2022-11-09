using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FullMessageView : MonoBehaviour
{
    [SerializeField] private Image _messageImage;
    [SerializeField] private TMP_Text _messageText;

    [Inject] private Player _player;

    private void OnEnable()
    {
        _player.PlayerFull += OnPlayerFull;
        _player.PlayerNotFullMore += OnPlayerNotFullMore;
    }

    private void OnDisable()
    {
        _player.PlayerFull -= OnPlayerFull;
        _player.PlayerNotFullMore -= OnPlayerNotFullMore;
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
}
