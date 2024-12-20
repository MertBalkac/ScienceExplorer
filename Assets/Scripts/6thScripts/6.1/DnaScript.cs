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
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(dnaPlay());
    }

    IEnumerator dnaPlay()
    {
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(TypeSentence("Transcription"));
        yield return new WaitForSeconds(0.5f);
        dnaCopy.SetActive(true);
        rnaText.SetActive(true);
        //dnaCopy anim
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(TypeSentence2("Translation"));
        yield return new WaitForSeconds(0.5f);
        protein.SetActive(true);
        proteinText.SetActive(true);
        yield return new WaitForSeconds(2f);



    }

    IEnumerator TypeSentence(string sentence)
    {
        talkingText.text = ""; // �nceki metni temizle
        arrow1.SetActive(true);
        foreach (char letter in sentence.ToCharArray())
        {
            talkingText.text += letter; // Her bir harfi s�rayla ekle
            yield return new WaitForSeconds(typingSpeed); // Harfler aras�ndaki gecikme s�resi
        }
    }
    IEnumerator TypeSentence2(string sentence)
    {
        talkingText2.text = ""; // �nceki metni temizle
        arrow2.SetActive(true);
        foreach (char letter in sentence.ToCharArray())
        {
            talkingText2.text += letter; // Her bir harfi s�rayla ekle
            yield return new WaitForSeconds(typingSpeed); // Harfler aras�ndaki gecikme s�resi
        }
    }
}
