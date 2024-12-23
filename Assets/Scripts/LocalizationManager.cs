using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Button _languageButton;

    private LanguageType _currentLanguage = LanguageType.English;
    // Mevcut dil ayarý; dilinizi istediðiniz gibi varsayýlan olarak atayabilirsiniz.

    private void Start()
    {
        // Butona týklandýðýnda ToggleLanguage fonksiyonu çaðrýlacak
        _languageButton.onClick.AddListener(ToggleLanguage);
    }

    // Mevcut dili kontrol edip diðeriyle deðiþtirir
    private void ToggleLanguage()
    {
        if (_currentLanguage == LanguageType.English)
        {
            SetLanguage(LanguageType.Turkish);
            _currentLanguage = LanguageType.Turkish;
        }
        else
        {
            SetLanguage(LanguageType.English);
            _currentLanguage = LanguageType.English;
        }
    }

    public void SetLanguage(LanguageType languageType)
    {
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            // Burada locale.LocaleName'in, LanguageType enum’una karþýlýk gelip gelmediðini kontrol ediyoruz
            if (locale.LocaleName.Equals(languageType.ToString()))
            {
                LocalizationSettings.SelectedLocale = locale;
                Debug.Log("Language set to: " + locale.LocaleName);
                return;
            }
        }
        Debug.LogWarning("Locale not found for " + languageType.ToString());
    }
}
