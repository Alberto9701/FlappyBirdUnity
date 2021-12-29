using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFlapToRestart : MonoBehaviour
{
    public GameObject flapToRestart;
    private float delay = 1.5f;


    private void OnEnable()
    {
        Invoke("EnabledFlapToRestart", delay);
    }

    void EnabledFlapToRestart()
    {
        flapToRestart.SetActive(true);
    }
}
