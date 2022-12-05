using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuLeaderboard : MonoBehaviour
{
    [SerializeField] private ButtonClickReader _leaderboardButton;
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
        _leaderboardButton.ButtonClicked += OnButtonClicked;
    }

    private void OnDisable() 
    {
        _leaderboardButton.ButtonClicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        if (_autorization.IsAutorized )
        {
            _leaderboard.SetActive(true);
        }
        else
        {
            _autorizationBoard.SetActive(true);
        }
    }
}
