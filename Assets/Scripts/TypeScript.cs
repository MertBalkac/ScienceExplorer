using System.Collections;
using TMPro;
using UnityEngine;

public class TypeScript : MonoBehaviour
{
    [Header("TextMeshPro Referanslarý")]
    [SerializeField] private TMP_Text sourceText;   // Metni buradan çekeceðiz
    [SerializeField] private TMP_Text typingText;   // Yazý efektini burada göstereceðiz

    [Header("Yazý Ayarlarý")]
    [SerializeField] private float typingSpeed = 0.05f; // Harfler arasý gecikme

    public void Type()
    {
        // Daha önce çalýþan yazý efekti varsa durdurup sýfýrla
        StopAllCoroutines();
        typingText.text = "";

        // Kaynak metni alarak Coroutine baþlat
        StartCoroutine(TypeSentence(sourceText.text));
    }

    public void ResetText()
    {
        // Çalýþan tüm Coroutine'leri durdur
        StopAllCoroutines();

        // Hedef metni sýfýrla
        typingText.text = "";
    }

    private IEnumerator TypeSentence(string sentence)
    {
        // Önce hedef metnimizi boþaltalým
        typingText.text = "";

        // Kaynaktan gelen metni harf harf yazdýralým
        foreach (char letter in sentence.ToCharArray())
        {
            typingText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
