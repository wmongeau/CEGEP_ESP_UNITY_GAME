using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckpointControlleur : MonoBehaviour
{
    GameObject canvas;
    Text txtCheckpoint;
    Text[] textes;
    GameObject Ty;
    JoueurControlleur Joueur;
    Personnages personnage;
    TimerScript timer;
    bool fade = false;
    float alpha = 1;
    float r;
    float g;
    float b;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        textes = canvas.GetComponentsInChildren<Text>();
        foreach (Text t in textes)
        {
            if (t.name=="TxtCheckpoint")
            {
                txtCheckpoint = t;
            }
        }
        r = txtCheckpoint.color.r;
        g = txtCheckpoint.color.g;
        b = txtCheckpoint.color.b;
        txtCheckpoint.enabled = false;
    }
    /// <summary>
    /// Sauvegarde la position et le temps du joueur et fait apparaitre un text
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.tag == "Final")
        {
            StartCoroutine("ChangerScene");
        }
        else if (other.name == "ty")
        {
            txtCheckpoint.color= new Color(txtCheckpoint.color.r,txtCheckpoint.color.g,txtCheckpoint.color.b,1);
            txtCheckpoint.enabled = true;
            Ty = other.gameObject;
            Joueur = Ty.GetComponent<JoueurControlleur>();
            timer = Ty.GetComponent<TimerScript>();
            personnage = Joueur.positionTy;
            personnage.PositionIni = other.transform.position;
            personnage.TempsIni = timer.temps;
            fade = true;
        }
      
    }
    /// <summary>
    /// Retourne le joueur au checkpoint si il pèse sur R
    /// </summary>
    private void Update()
    {
        if (Input.GetKey("r"))
        {
            Vector3 déplacement = personnage.PositionIni;
            Ty.transform.position = déplacement;
            timer.temps = personnage.TempsIni;
        }
        if(txtCheckpoint!=null&&fade)
        {
            if(alpha>0)
            {
                alpha -= 0.03f;
                txtCheckpoint.color = new Color(r, g, b, alpha);
            }
            if (alpha<=0)
            {
                alpha = 1;
                txtCheckpoint.color = new Color(r,g, b, alpha);
                txtCheckpoint.enabled = false;
                fade = false;
            }
        }
       
    }
    IEnumerator ChangerScene()
    {
        float tempsTransition = GameObject.Find("Canvas").GetComponent<TransitionScene>().DebutTransition(1);
        yield return new WaitForSeconds(tempsTransition);
        SceneManager.LoadScene(3);
    }
}
