using Agava.YandexGames;
using UnityEngine;

public class LanguageDetector : MonoBehaviour
{
    private void Awake()
    {
        var language = YandexGamesSdk.Environment.i18n.lang;

        switch (language)
        {
            case "ru":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "be":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "kk":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "uz":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "uk":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
                break;
            case "tr":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Turkish");
                break;
            case "en":
                Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
                break;
        }
    }

}
