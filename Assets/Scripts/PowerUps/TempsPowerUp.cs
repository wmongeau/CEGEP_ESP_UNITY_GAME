using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TempsPowerUp : MonoBehaviour {

    float temps;
    
    [SerializeField]
    Sprite slowmo;
    [SerializeField]
    Sprite arret;
    [SerializeField]
    Sprite doubleSaut;
    [SerializeField]
    Sprite mini;

    [SerializeField]
    Image timer;

    [SerializeField]
    Image centre;

    [SerializeField]
    Image image;

    [SerializeField]
    Image loading;




    // Use this for initialization
    void Start ()
    {
        timer.enabled=false;
        centre.enabled = false;
        image.enabled = false;
        loading.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        temps -= Time.unscaledDeltaTime;
        if (temps <= 0)
        {
            timer.enabled=false;
            centre.enabled = false;
            image.enabled = false;
            loading.enabled = false;
        }
        else
        {
            loading.fillAmount = temps / 10;
        }
	}
    public void DebutTemps(int methode)
    {
        switch (methode)
        {
            case 0:
                image.sprite = slowmo;
            break;
            case 1:
                image.sprite = arret;
                break;
            case 2:
                image.sprite = mini;
                break;
            case 3:
                image.sprite = doubleSaut;
                break;
        }
        timer.enabled = true;
        centre.enabled = true;
        image.enabled = true;
        loading.enabled = true;
        temps = 10;
    }
}
