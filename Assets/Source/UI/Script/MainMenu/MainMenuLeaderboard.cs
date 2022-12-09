using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuLeaderboard : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _leaderboardButton;
    [SerializeField] private ButtonClickReader _closeButton;
    [SerializeField] private Image _leaderboardImage;
    [SerializeField] private Image _autorizationBoardImage;

    [Inject] private Autorization _autorization;

    private GameObject _leaderboard;
    private GameObject _autorizationBoard;

    private void Awake()
    {
        _leaderboard = _leaderboardImage.gameObject;
        _autorizationBoard = _autorizationBoardImage.gameObject;
    }

    private void OnEnable()
    {
        _leaderboardButton.ButtonClicked += OLeaderboardButtonClicked;
        _closeButton.ButtonClicked += OnCloseButtonClicked;
    }

    private void OnDisable() 
    {
        _leaderboardButton.ButtonClicked -= OLeaderboardButtonClicked;
        _closeButton.ButtonClicked += OnCloseButtonClicked;
    }

    private void OLeaderboardButtonClicked()
    {
        if (_autorization.IsAutorized)
        {
            _leaderboard.SetActive(true);
        }
        else
        {
            _autorizationBoard.SetActive(true);
        }
    }

    private void OnCloseButtonClicked()
    {
        _leaderboard.SetActive(false);
    }
}
