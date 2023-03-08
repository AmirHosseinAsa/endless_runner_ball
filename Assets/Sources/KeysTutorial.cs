using System.Collections;
using UnityEngine;

public class KeysTutorial : MonoBehaviour
{
    [SerializeField] GameObject Tutorial;
    bool showedKeyBindings = false;
    bool isShowing = false;

    void Update()
    {
        if (showedKeyBindings == false && SaveScript.IsItFirstTimeRunning == false)
        {
            isShowing = true;
            StartCoroutine(HideKeyBindiingsAfterSeccounds());
        }
        else if (SaveScript.IsOptionsPanelActive)
            isShowing = true;
        else if (showedKeyBindings)
            isShowing = false;

        Tutorial.SetActive(isShowing);

    }
    IEnumerator HideKeyBindiingsAfterSeccounds()
    {
        yield return new WaitForSeconds(10f);
        Tutorial.SetActive(false);
        showedKeyBindings = true;
    }
}
