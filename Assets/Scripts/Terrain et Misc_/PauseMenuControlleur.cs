using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuControlleur : MonoBehaviour
{
    bool MenuEstActif = false;

    [SerializeField]
    GameObject parametres;

    [SerializeField]
    GameObject PanelMenu;

    [SerializeField]
    Slider son;

    [SerializeField]
    Slider SldSensibilité;

    [SerializeField]
    Slider SldCtrl;

    [SerializeField]
    GameObject Ty;

    int choixClavier = 0;

    Camera cam;
    CameraControlleur scriptCam;
    PS4Camera scriptCamPs4;
    JoueurControlleur scriptJoueur;
    PS4Controller scriptPS4controller;

    void Start ()
    {
        cam = Camera.main;
        PanelMenu.SetActive(false);
        parametres.SetActive(false);

        scriptCam = cam.GetComponent<CameraControlleur>();
        scriptCamPs4 = cam.GetComponent<PS4Camera>();
        scriptJoueur = Ty.GetComponent<JoueurControlleur>();
        scriptPS4controller = Ty.GetComponent<PS4Controller>();

        if(SldCtrl.value != 0)
        {
            SldCtrl.value = PlayerPrefs.GetInt("Ctrl");
        }
        
        if (PlayerPrefs.GetFloat("Sensibilité")!=0)
        {
            SldSensibilité.value = PlayerPrefs.GetFloat("Sensibilité");
        }
        choixClavier = PlayerPrefs.GetInt("choixClavier");
        if (PlayerPrefs.GetInt("choixClavier")==0)
        {
            scriptPS4controller.enabled = false;
            scriptCamPs4.enabled = false;
            scriptCam.enabled = true;
            scriptJoueur.enabled = true;
        }
        else
        {
            scriptPS4controller.enabled = true;
            scriptJoueur.enabled = false;
            scriptCamPs4.enabled = true;
            scriptCam.enabled = false;
        }
        son.value = PlayerPrefs.GetFloat("Volume");       
    }	
	
	void Update ()
    {
        if (Input.GetKeyDown("escape") || Input.GetButtonDown("Options"))
        {
            MenuEstActif = !MenuEstActif;

            if (MenuEstActif)
            {
                PanelMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                FermerMenu();
            }
        }     
    }

    public void RetournerMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void FermerMenu()
    {
        parametres.SetActive(false);
        PanelMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangerSon()
    {
        float volume = son.value;
        PlayerPrefs.SetFloat("Volume", volume);
        AudioListener.volume = volume; 
    }
    public void ChangerSensibilité()
    {
        int sensibilite = (int)SldSensibilité.value;
        PlayerPrefs.SetFloat("Sensibilité", sensibilite);       
        scriptCam.sensibilité = sensibilite;   
    }
    public void ChangerCtrl()
    {
        int ctrl = (int)SldCtrl.value;
        PlayerPrefs.SetInt("Ctrl", ctrl);
        scriptCam.typeCtrl = ctrl;
    }

    public void Clavier()
    {
        choixClavier = 0;
        PlayerPrefs.SetInt("choixClavier",choixClavier);
        scriptPS4controller.enabled = false;
        scriptCamPs4.enabled = false;
        scriptCam.enabled = true;
        scriptJoueur.enabled = true;

    }
    public void Manette()
    {
        choixClavier = 1;
        PlayerPrefs.SetInt("choixClavier", choixClavier);
        scriptPS4controller.enabled = true;
        scriptJoueur.enabled = false;
        scriptCamPs4.enabled = true;
        scriptCam.enabled = false;
    }
    public void Parametre()
    {
        parametres.SetActive(true);
        PanelMenu.SetActive(false);
    }
}
