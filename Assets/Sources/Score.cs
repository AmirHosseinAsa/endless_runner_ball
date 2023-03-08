using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject MaximumScore;
    [SerializeField] GameObject CurrentScore;

    [SerializeField] Text MaximumScoreText;
    [SerializeField] Text CurrentScoreText;

    void Start()
    {
        StartCoroutine(IncreaseScore());
        SaveScript.MaximumScore = SaveSystem.LoadMaximumScore().MaximumScore;
    }


    void Update()
    {
        MaximumScore.SetActive(!SaveScript.IsItFirstTimeRunning && !SaveScript.IsOptionsPanelActive);
        MaximumScoreText.text = SaveScript.MaximumScore.ToString();

        if (!SaveScript.IsItFirstTimeRunning && !SaveScript.IsOptionsPanelActive) { CurrentScore.SetActive(true); CurrentScoreText.text = SaveScript.CurrentScore.ToString(); }
        else
            CurrentScore.SetActive(false);
    }


    IEnumerator IncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(.9f);
            if (!SaveScript.IsItFirstTimeRunning && !SaveScript.IsOptionsPanelActive && !SaveScript.IsDead)
            {
                SaveScript.CurrentScore += 1;
            }
        }
    }
}
