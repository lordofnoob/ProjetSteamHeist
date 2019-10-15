using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    List<string> ActionToPerform;
    public float tickInterval = 0.5f;
    void Awake()
    {
        ActionToPerform = new List<string>();
        StartCoroutine(Sequencer());
    }

    IEnumerator Sequencer()
    {
        yield return new WaitForSeconds(tickInterval);

        PerformAction();

        StartCoroutine(Sequencer());
    }

    void PerformAction()
    {
        foreach(var action in ActionToPerform)
        {
            print(action);
        }
        ActionToPerform.Clear();
    }

    public void AddActionToPerform(string action)
    {
        ActionToPerform.Add(action);
    }
}
