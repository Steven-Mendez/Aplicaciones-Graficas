using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public bool addingDis = false;
    public float disDelay = 0.35F;

    private void Start()
    {
        StartCoroutine(AddSpeed());
    }

    void Update()
    {
        if (!addingDis)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun++;
        disDisplay.GetComponent<Text>().text = disRun.ToString();
        disEndDisplay.GetComponent<Text>().text = disRun.ToString();
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }

    IEnumerator AddSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            PlayerMove.moveSpeed *= 1.1f;
        }
    }
}
