using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Button _languageButton;

    private LanguageType _currentLanguage;

    private void Start()
    {
        _currentLanguage = GetCurrentLanguageFromDataTables();
        SetLanguage(_currentLanguage);
        if(_languageButton != null)
            _languageButton.onClick.AddListener(ToggleLanguage);
    }

    private LanguageType GetCurrentLanguageFromDataTables()
    {
        string currentLang = DataTablesManager.GetCurrentLanguage();
        if (System.Enum.TryParse(currentLang, out LanguageType language))
        {
            return language;
        }
        else
        {
            Debug.LogWarning("Geçersiz dil deðeri: " + currentLang +
                             ". Varsayýlan dil olarak English ayarlandý.");
            return LanguageType.English;
        }
    }

    private void ToggleLanguage()
    {
        if(_languageButton != null)
        {
            if (_currentLanguage == LanguageType.English)
            {
                _currentLanguage = LanguageType.Turkish;
            }
            else
            {
                _currentLanguage = LanguageType.English;
            }
        }

        SetLanguage(_currentLanguage);
        SaveCurrentLanguageToDataTables(_currentLanguage);
    }

    public void SetLanguage(LanguageType languageType)
    {
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.LocaleName.Equals(languageType.ToString()))
            {
                LocalizationSettings.SelectedLocale = locale;
                Debug.Log("Language set to: " + locale.LocaleName);
                return;
            }
        }
        Debug.LogWarning("Locale not found for " + languageType.ToString());
    }

    private void SaveCurrentLanguageToDataTables(LanguageType language)
    {
        DataTablesManager.SetCurrentLanguage(language.ToString());
    }

    // DnaScript'in eriþebileceði basit bir getter
    public LanguageType GetCurrentLanguage()
    {
        return _currentLanguage;
    }
}
