using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Button _languageButton;

    private LanguageType _currentLanguage;

    private void Start()
    {
        // 1) DataTables�tan mevcut dili �ek
        _currentLanguage = GetCurrentLanguageFromDataTables();

        // 2) Uygulama a��l�r a��lmaz, dil ayar�n� yap
        SetLanguage(_currentLanguage);

        // 3) Butona t�kland���nda ToggleLanguage �a��r
        _languageButton.onClick.AddListener(ToggleLanguage);
    }

    // �u anki dil tipini DataTables�tan alan �rnek metot
    private LanguageType GetCurrentLanguageFromDataTables()
    {
        // Burada DataTables (veya benzeri) taraf�ndaki fonksiyonunuzu �a��r�p
        // geriye "English" veya "Turkish" vb. string d�nd�rd���n� varsay�yoruz.
        string currentLang = DataTablesManager.GetCurrentLanguage();

        // String -> Enum d�n��t�rme
        // D�n���m ba�ar�l� olmazsa varsay�lan olarak English se�iyoruz (�rnek).
        if (System.Enum.TryParse(currentLang, out LanguageType language))
        {
            return language;
        }
        else
        {
            Debug.LogWarning("Ge�ersiz dil de�eri: " + currentLang + ". Varsay�lan dil olarak English ayarland�.");
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

        // 4) Yeni dili hem Unity Localization�a hem de DataTables�a uygula
        SetLanguage(_currentLanguage);
        SaveCurrentLanguageToDataTables(_currentLanguage);
    }

    // Unity Localization�daki dili de�i�tiren metot
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

    // DataTables taraf�na g�ncel dili kaydetmek i�in �rnek metot
    private void SaveCurrentLanguageToDataTables(LanguageType language)
    {
        DataTablesManager.SetCurrentLanguage(language.ToString());
    }
}
