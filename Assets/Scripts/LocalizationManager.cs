using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Button _languageButton;

    private LanguageType _currentLanguage;

    private void Start()
    {
        // 1) DataTables’tan mevcut dili çek
        _currentLanguage = GetCurrentLanguageFromDataTables();

        // 2) Uygulama açýlýr açýlmaz, dil ayarýný yap
        SetLanguage(_currentLanguage);

        // 3) Butona týklandýðýnda ToggleLanguage çaðýr
        _languageButton.onClick.AddListener(ToggleLanguage);
    }

    // Þu anki dil tipini DataTables’tan alan örnek metot
    private LanguageType GetCurrentLanguageFromDataTables()
    {
        // Burada DataTables (veya benzeri) tarafýndaki fonksiyonunuzu çaðýrýp
        // geriye "English" veya "Turkish" vb. string döndürdüðünü varsayýyoruz.
        string currentLang = DataTablesManager.GetCurrentLanguage();

        // String -> Enum dönüþtürme
        // Dönüþüm baþarýlý olmazsa varsayýlan olarak English seçiyoruz (örnek).
        if (System.Enum.TryParse(currentLang, out LanguageType language))
        {
            return language;
        }
        else
        {
            Debug.LogWarning("Geçersiz dil deðeri: " + currentLang + ". Varsayýlan dil olarak English ayarlandý.");
            return LanguageType.English;
        }
    }

    private void ToggleLanguage()
    {
        if (_currentLanguage == LanguageType.English)
        {
            _currentLanguage = LanguageType.Turkish;
        }
        else
        {
            _currentLanguage = LanguageType.English;
        }

        // 4) Yeni dili hem Unity Localization’a hem de DataTables’a uygula
        SetLanguage(_currentLanguage);
        SaveCurrentLanguageToDataTables(_currentLanguage);
    }

    // Unity Localization’daki dili deðiþtiren metot
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

    // DataTables tarafýna güncel dili kaydetmek için örnek metot
    private void SaveCurrentLanguageToDataTables(LanguageType language)
    {
        DataTablesManager.SetCurrentLanguage(language.ToString());
    }
}
