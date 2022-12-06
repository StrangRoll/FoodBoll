using TMPro;
using UnityEngine;

public class LeaderPosition : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _result;

    public void UpdateInfo(string name, string result)
    {
        _name.text = name + ":";
        _result.text = " " + result + " " + Lean.Localization.LeanLocalization.GetTranslationText("level");
    }
}

