using System.Collections;
using TMPro;
using UnityEngine;

public class TypeScript : MonoBehaviour
{
    [Header("TextMeshPro Referanslarý")]
    [SerializeField] private TMP_Text sourceText;
    [SerializeField] private TMP_Text typingText;

    [Header("Yazý Ayarlarý")]
    [SerializeField] private float typingSpeed = 0.05f; 

    public void Type()
    {
        StopAllCoroutines();
        typingText.text = "";
        StartCoroutine(TypeSentence(sourceText.text));
    }

    public void ResetText()
    {
        StopAllCoroutines();
        typingText.text = "";
    }

    private IEnumerator TypeSentence(string sentence)
    {
        typingText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            typingText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
