using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScene : MonoBehaviour {

    [SerializeField]
    Texture2D noir;
    [SerializeField]
    float vitesseTransition;

    private float alpha = 1.0f;
    private int dirTransition=-1;

    private void OnGUI()
    {
        alpha += dirTransition * vitesseTransition * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), noir);

    }
    public float DebutTransition(int direction)
    {
        dirTransition = direction;
        return (vitesseTransition);
    }
    private void OnLevelWasLoaded()
    {
        DebutTransition(-1);  
    }
}
