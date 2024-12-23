using System.Collections;
using TMPro;
using UnityEngine;

public class TypeScript : MonoBehaviour
{
    [Header("TextMeshPro Referanslar�")]
    [SerializeField] private TMP_Text sourceText;   // Metni buradan �ekece�iz
    [SerializeField] private TMP_Text typingText;   // Yaz� efektini burada g�sterece�iz

    [Header("Yaz� Ayarlar�")]
    [SerializeField] private float typingSpeed = 0.05f; // Harfler aras� gecikme

    public void Type()
    {
        // Daha �nce �al��an yaz� efekti varsa durdurup s�f�rla
        StopAllCoroutines();
        typingText.text = "";

        // Kaynak metni alarak Coroutine ba�lat
        StartCoroutine(TypeSentence(sourceText.text));
    }

    public void ResetText()
    {
        // �al��an t�m Coroutine'leri durdur
        StopAllCoroutines();

        // Hedef metni s�f�rla
        typingText.text = "";
    }

    private IEnumerator TypeSentence(string sentence)
    {
        // �nce hedef metnimizi bo�altal�m
        typingText.text = "";

        // Kaynaktan gelen metni harf harf yazd�ral�m
        foreach (char letter in sentence.ToCharArray())
        {
            typingText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
