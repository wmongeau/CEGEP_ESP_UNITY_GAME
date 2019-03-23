using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    Text timer;

    public float temps=0;
    public bool compterTemps=true;

    void Update ()
    {
        if (compterTemps)
        {
            temps += Time.deltaTime*Time.timeScale;
        }
        timer.text = temps.ToString();
	}
}
