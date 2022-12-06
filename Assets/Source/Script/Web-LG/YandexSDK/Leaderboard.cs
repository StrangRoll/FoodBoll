using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Agava.YandexGames;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<LeaderPosition> _positions;
    [SerializeField] private TMP_Text _playerPosition;

    [Inject] private Autorization _autorization;

    private int _topPlayerCount = 6;

    private void OnEnable()
    {
        Agava.YandexGames.Leaderboard.GetEntries(LeaderBoardName.World, (result) => OnleaderboearInfoGot(result), (result) => OnError(result), 6, 6, true);
    }
        
    private void OnleaderboearInfoGot(LeaderboardGetEntriesResponse result)
    {
        var index = 0;
        var userRank = result.userRank;
        var isUserTop = (userRank >= _topPlayerCount);

        foreach (var entry in result.entries)
        {
            string name = entry.player.publicName;

            if (string.IsNullOrEmpty(name))
                name = Lean.Localization.LeanLocalization.GetTranslationText("Unknown player");

            _positions[index].UpdateInfo(name, entry.score.ToString());
            index++;
        }

        if (isUserTop == false)
            Agava.YandexGames.Leaderboard.GetPlayerEntry(_autorization.PlayerName, (result) =>
            {
                _positions[_topPlayerCount - 1].UpdateInfo(_autorization.PlayerName, result.score.ToString());
            });

        _playerPosition.text = userRank.ToString();
    }

    private void OnError(string something)
    {
        Debug.Log(something);

        foreach (var position in _positions)
        {
            position.UpdateInfo("Произошла ","ошибка");
        }
    }
}
