using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    [System.Serializable]
    public class Stage
    {
        public GameObject stageObject;
        public GameObject infoTextObject;
    }

    public List<Stage> stages; 
    public Transform targetPosition;
    public Transform offScreenPosition; 
    public GameObject nextButton; 
    public float moveSpeed = 2f; 

    private int currentStageIndex = 0;

    void Start()
    {
        for (int i = 0; i < stages.Count; i++)
        {
            if (i == 0)
            {
                stages[i].stageObject.transform.position = targetPosition.position;
                stages[i].infoTextObject.SetActive(true); 
            }
            else
            {
                stages[i].stageObject.transform.position = offScreenPosition.position;
                stages[i].infoTextObject.SetActive(false);
            }
        }
    }

    public void OnNextButtonPressed()
    {
        if (currentStageIndex < stages.Count - 1)
        {
            nextButton.SetActive(false); 
            StartCoroutine(SwitchStage());
        }
    }

    private IEnumerator SwitchStage()
    {
        GameObject currentStage = stages[currentStageIndex].stageObject;
        stages[currentStageIndex].infoTextObject.SetActive(false);
        while (Vector3.Distance(currentStage.transform.position, offScreenPosition.position) > 0.01f)
        {
            currentStage.transform.position = Vector3.MoveTowards(currentStage.transform.position, offScreenPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        currentStageIndex++;
        GameObject nextStage = stages[currentStageIndex].stageObject;
        while (Vector3.Distance(nextStage.transform.position, targetPosition.position) > 0.01f)
        {
            nextStage.transform.position = Vector3.MoveTowards(nextStage.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        stages[currentStageIndex].infoTextObject.SetActive(true);
        nextButton.SetActive(true);
    }
}
