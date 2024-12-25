using UnityEngine;

public static class DataTablesManager
{
    public static string GetCurrentLanguage()
    {
        return PlayerPrefs.GetString("CurrentLanguage", "English");
    }

    public static void SetCurrentLanguage(string newLanguage)
    {
        PlayerPrefs.SetString("CurrentLanguage", newLanguage);
    }
}

