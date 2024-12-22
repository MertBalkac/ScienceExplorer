using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    [System.Serializable]
    public class Stage
    {
        public GameObject stageObject; // Sahnedeki obje
        public string infoText; // TextMeshPro için bilgi metni
    }

    public List<Stage> stages; // Tüm stage'ler
    public Transform targetPosition; // Objelerin yavaþça gideceði hedef pozisyon
    public Transform offScreenPosition; // Bir sonraki obje ekrana gelmeden önce bulunacaðý pozisyon
    public TextMeshProUGUI infoTextDisplay; // Bilgi metnini gösterecek TextMeshPro
    public GameObject nextButton; // "Next" butonu
    public float moveSpeed = 2f; // Hareket hýzý

    private int currentStageIndex = 0;

    void Start()
    {
        // Ýlk stage'i hedef pozisyonda aktif yap
        for (int i = 0; i < stages.Count; i++)
        {
            if (i == 0)
            {
                stages[i].stageObject.transform.position = targetPosition.position;
                infoTextDisplay.text = stages[i].infoText;
            }
            else
            {
                stages[i].stageObject.transform.position = offScreenPosition.position;
            }
        }
    }

    public void OnNextButtonPressed()
    {
        if (currentStageIndex < stages.Count - 1)
        {
            nextButton.SetActive(false); // Butonu gizle
            StartCoroutine(SwitchStage());
        }
    }

    private IEnumerator SwitchStage()
    {
        // Mevcut stage'i hedef pozisyondan off-screen pozisyonuna taþý
        GameObject currentStage = stages[currentStageIndex].stageObject;
        while (Vector3.Distance(currentStage.transform.position, offScreenPosition.position) > 0.01f)
        {
            currentStage.transform.position = Vector3.MoveTowards(currentStage.transform.position, offScreenPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Bir sonraki stage'i hedef pozisyona taþý
        currentStageIndex++;
        GameObject nextStage = stages[currentStageIndex].stageObject;
        while (Vector3.Distance(nextStage.transform.position, targetPosition.position) > 0.01f)
        {
            nextStage.transform.position = Vector3.MoveTowards(nextStage.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Yeni stage için bilgi metnini güncelle
        infoTextDisplay.text = stages[currentStageIndex].infoText;

        // Butonu tekrar görünür yap
        nextButton.SetActive(true);
    }
}
