using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DnaScript : MonoBehaviour
{
    [SerializeField] private TMP_Text talkingText;
    [SerializeField] private TMP_Text talkingText2;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] GameObject dnaCopy;
    [SerializeField] GameObject protein;
    [SerializeField] GameObject arrow1;
    [SerializeField] GameObject arrow2;
    [SerializeField] GameObject rnaText;
    [SerializeField] GameObject proteinText;
    [SerializeField] GameObject infoText;

    // LocalizationManager'a eriþim için referans
    private LocalizationManager _localizationManager;

    void Start()
    {
        // Sahnede bir LocalizationManager olduðunu varsayarak buluyoruz.
        _localizationManager = FindObjectOfType<LocalizationManager>();

        StartCoroutine(dnaPlay());
    }

    IEnumerator dnaPlay()
    {
        // Önce sahnede 2 saniye bekleyelim
        yield return new WaitForSeconds(2f);

        // Mevcut dile göre kelimeleri belirleyelim
        var currentLanguage = _localizationManager.GetCurrentLanguage();
        string transcriptionText = currentLanguage == LanguageType.English
                                   ? "Transcription"
                                   : "Transkripsiyon";
        string translationText = currentLanguage == LanguageType.English
                                 ? "Translation"
                                 : "Translasyon";

        // 1) Transcription veya Transkripsiyon
        yield return StartCoroutine(TypeSentence(transcriptionText));
        yield return new WaitForSeconds(0.5f);

        // Bu kýsýmda DNA’nýn kopyalanma objelerini aktif ediyoruz
        dnaCopy.SetActive(true);
        rnaText.SetActive(true);

        yield return new WaitForSeconds(3f);

        // 2) Translation veya Translasyon
        yield return StartCoroutine(TypeSentence2(translationText));
        yield return new WaitForSeconds(0.5f);

        // Proteinle ilgili objeleri gösteriyoruz
        protein.SetActive(true);
        proteinText.SetActive(true);
        infoText.SetActive(true);

        yield return new WaitForSeconds(2f);
    }

    IEnumerator TypeSentence(string sentence)
    {
        talkingText.text = "";
        arrow1.SetActive(true);
        foreach (char letter in sentence.ToCharArray())
        {
            talkingText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator TypeSentence2(string sentence)
    {
        talkingText2.text = "";
        arrow2.SetActive(true);
        foreach (char letter in sentence.ToCharArray())
        {
            talkingText2.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
