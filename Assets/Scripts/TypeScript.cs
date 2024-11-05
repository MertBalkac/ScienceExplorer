using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] string experimentText;
    [SerializeField] private float typingSpeed = 0.05f;

    public void type()
    {
        StartCoroutine(TypeSentence(experimentText));
    }
    public void ResetText()
    {
        StopAllCoroutines();
        text.text = "";

    }
    IEnumerator TypeSentence(string sentence)
    {
        text.text = ""; // Önceki metni temizle
            foreach (char letter in sentence.ToCharArray())
            {
                text.text += letter; // Her bir harfi sýrayla ekle
                yield return new WaitForSeconds(typingSpeed); // Harfler arasýndaki gecikme süresi
            } 
    }
}
