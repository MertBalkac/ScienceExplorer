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
        public string infoText; // TextMeshPro i�in bilgi metni
    }

    public List<Stage> stages; // T�m stage'ler
    public Transform targetPosition; // Objelerin yava��a gidece�i hedef pozisyon
    public Transform offScreenPosition; // Bir sonraki obje ekrana gelmeden �nce bulunaca�� pozisyon
    public TextMeshProUGUI infoTextDisplay; // Bilgi metnini g�sterecek TextMeshPro
    public GameObject nextButton; // "Next" butonu
    public float moveSpeed = 2f; // Hareket h�z�

    private int currentStageIndex = 0;

    void Start()
    {
        // �lk stage'i hedef pozisyonda aktif yap
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
        // Mevcut stage'i hedef pozisyondan off-screen pozisyonuna ta��
        GameObject currentStage = stages[currentStageIndex].stageObject;
        while (Vector3.Distance(currentStage.transform.position, offScreenPosition.position) > 0.01f)
        {
            currentStage.transform.position = Vector3.MoveTowards(currentStage.transform.position, offScreenPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Bir sonraki stage'i hedef pozisyona ta��
        currentStageIndex++;
        GameObject nextStage = stages[currentStageIndex].stageObject;
        while (Vector3.Distance(nextStage.transform.position, targetPosition.position) > 0.01f)
        {
            nextStage.transform.position = Vector3.MoveTowards(nextStage.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Yeni stage i�in bilgi metnini g�ncelle
        infoTextDisplay.text = stages[currentStageIndex].infoText;

        // Butonu tekrar g�r�n�r yap
        nextButton.SetActive(true);
    }
}
