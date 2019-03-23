using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonControlleur : MonoBehaviour
{
    [SerializeField]
    GameObject PanelMenu;
    public void ChargerNiveau()
    {
        SceneManager.LoadScene(2);
    }
    public void ChargerTutoriel()
    {
        SceneManager.LoadScene(1);
    }

    public void Réglages()
    {
        PanelMenu.SetActive(true);
    }
    public void Quitter()
    {
        Application.Quit();
    }
	
}
