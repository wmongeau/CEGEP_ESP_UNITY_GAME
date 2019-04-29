using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeTexturéFlottant : MonoBehaviour
{
    [SerializeField]
    int temps;
    const int NB_SOMMETS_CUBE = 8;
    const int NB_TUILES_CUBE = 6;
    const float DEMI = 0.5f;
    const int NB_TRIANGLES_PAR_TUILE = 2;
    const int NB_SOMMETS_PAR_TRIANGLE = 3;
    const int NB_DEGRÉS_ROTATION_PAR_SECONDE = 90;
    const float ÉLÉVATION_VERTICALE = 0.50f;

    GameObject timer;

    //Les différents effets pour les explosions
    [SerializeField]
    GameObject fx;

    [SerializeField]
    GameObject fx1;

    [SerializeField]
    GameObject fx2;

    [SerializeField]
    GameObject fx3;
    
    [SerializeField]    
    Vector3 Étendue;

    //[SerializeField]   
    //AudioClip SonDestruction;    

    GameObject effet;

    //Les différentes caractéristiques d'un cube
    public Vector3 Origine;
    float delta = -1;

    Mesh Maillage;

    float Largeur;
    float Longueur;
    float Profondeur;
    int NbSommets;
    int NbTriangles;
    float compteur = 0;
    Vector3[] Sommets;

    //Utilisé pour certains power-ups
    TimerScript scriptTemps;

    //Pour modifier certains aspects fixes du joueur
    JoueurControlleur scriptTy;
    PS4Controller scriptPS4;
    System.Random rng = new System.Random();
    int nbMéthode;

    static int dernierPowerUp;


    GameObject canvas;
    TempsPowerUp scriptTempsPU;

    //Les différents power-ups possibles pour le joueur
    static bool mini = false;
    static bool slowmo = false;
    static bool doubleSaut = false;
    static bool arrêt = false;

    //La formule classique de génération d'un cube procéduralement
    #region Génération des cubes

    void Awake()
    {
        canvas = GameObject.Find("Canvas");
        scriptTempsPU = canvas.GetComponent<TempsPowerUp>();
        CalculerDonnéesDeBase();
        GénérerTriangles();
    }

    private void CalculerDonnéesDeBase()
    {

        Origine = new Vector3(0, ÉLÉVATION_VERTICALE, 0);
        Largeur = Étendue.x;
        Longueur = Étendue.z;
        Profondeur = Étendue.y;
        NbSommets = 14;
        Sommets = new Vector3[NbSommets];
        NbTriangles = NB_TRIANGLES_PAR_TUILE * NB_TUILES_CUBE * NB_SOMMETS_PAR_TRIANGLE;
    }

    private void GénérerTriangles()
    {
        Maillage = new Mesh();
        GetComponent<MeshFilter>().mesh = Maillage;
        Maillage.name = "Surface";
        GénérerSommets();
        GénérerListeTriangles();
    }

    private void GénérerSommets()
    {
        Sommets[0] = new Vector3(-Largeur * DEMI, -Longueur * DEMI, Profondeur * DEMI); //A
        Sommets[1] = new Vector3(Largeur * DEMI, -Longueur * DEMI, Profondeur * DEMI); //B
        Sommets[2] = new Vector3(Largeur * DEMI, -Longueur * DEMI, -Profondeur * DEMI); //C
        Sommets[3] = new Vector3(-Largeur * DEMI, -Longueur * DEMI, -Profondeur * DEMI); //D
        Sommets[4] = Sommets[0]; //A
        Sommets[5] = new Vector3(-Largeur * DEMI, Longueur * DEMI, Profondeur * DEMI); //E
        Sommets[6] = new Vector3(Largeur * DEMI, Longueur * DEMI, Profondeur * DEMI); //F
        Sommets[7] = new Vector3(Largeur * DEMI, Longueur * DEMI, -Profondeur * DEMI); //G
        Sommets[8] = new Vector3(-Largeur * DEMI, Longueur * DEMI, -Profondeur * DEMI); //H
        Sommets[9] = Sommets[5];
        Sommets[10] = Sommets[0];
        Sommets[11] = Sommets[3];

        Sommets[12] = Sommets[5];
        Sommets[13] = Sommets[8];


        Vector2[] coordonnéesTexture = new Vector2[NbSommets];

        coordonnéesTexture[0] = new Vector2(0, 0);
        coordonnéesTexture[1] = new Vector2(1, 0);
        coordonnéesTexture[2] = new Vector2(2, 0);
        coordonnéesTexture[3] = new Vector2(3, 0);
        coordonnéesTexture[4] = new Vector2(4, 0);
        coordonnéesTexture[5] = new Vector2(0, 1);
        coordonnéesTexture[6] = new Vector2(1, 1);
        coordonnéesTexture[7] = new Vector2(2, 1);
        coordonnéesTexture[8] = new Vector2(3, 1);
        coordonnéesTexture[9] = new Vector2(4, 1);
        coordonnéesTexture[10] = new Vector2(1, 1);
        coordonnéesTexture[11] = new Vector2(2, 1);
        coordonnéesTexture[12] = new Vector2(1, 0);
        coordonnéesTexture[13] = new Vector2(2, 0);

        Maillage.vertices = Sommets;
        Maillage.uv = coordonnéesTexture;
    }

    private void GénérerListeTriangles()
    {
        int[] triangles = new int[NbTriangles];
        int indice = 0;

        triangles[indice] = 0; indice++;
        triangles[indice] = 1; indice++;
        triangles[indice] = 5; indice++;
        triangles[indice] = 5; indice++;
        triangles[indice] = 1; indice++;
        triangles[indice] = 6; indice++;

        triangles[indice] = 6; indice++;
        triangles[indice] = 1; indice++;
        triangles[indice] = 2; indice++;
        triangles[indice] = 2; indice++;
        triangles[indice] = 7; indice++;
        triangles[indice] = 6; indice++;

        triangles[indice] = 2; indice++;
        triangles[indice] = 3; indice++;
        triangles[indice] = 7; indice++;
        triangles[indice] = 7; indice++;
        triangles[indice] = 3; indice++;
        triangles[indice] = 8; indice++;

        triangles[indice] = 3; indice++;
        triangles[indice] = 4; indice++;
        triangles[indice] = 8; indice++;
        triangles[indice] = 8; indice++;
        triangles[indice] = 4; indice++;
        triangles[indice] = 9; indice++;

        triangles[indice] = 10; indice++;
        triangles[indice] = 2; indice++;
        triangles[indice] = 1; indice++;
        triangles[indice] = 10; indice++;
        triangles[indice] = 11; indice++;
        triangles[indice] = 2; indice++;

        triangles[indice] = 6; indice++;
        triangles[indice] = 13; indice++;
        triangles[indice] = 12; indice++;
        triangles[indice] = 6; indice++;
        triangles[indice] = 7; indice++;
        triangles[indice] = 13; indice++;

        Maillage.triangles = triangles;
        Maillage.RecalculateNormals();
    }
    #endregion


    #region Gestion Power Up
    public void OnTriggerEnter(Collider other)
    {

        while (nbMéthode == dernierPowerUp)
        {
            nbMéthode = rng.Next(0, 4);
        }
        dernierPowerUp = nbMéthode;
        
        if (other.gameObject.name == "ty")
        {
            switch (nbMéthode)
            {
                case 0:
                    if (!slowmo)
                    {
                        StartCoroutine(SlowMo(temps));
                        scriptTempsPU.DebutTemps(nbMéthode);
                    }

                    break;
                case 1:
                    if (!arrêt)
                    {
                        StartCoroutine(ArrêtTemps(other, temps));
                        scriptTempsPU.DebutTemps(nbMéthode);
                    }

                    break;
                case 2:
                    if (!mini)
                    {
                        StartCoroutine(MiniJoueur(other, temps));
                        scriptTempsPU.DebutTemps(nbMéthode);
                    }

                    break;
                case 3:
                    if (!doubleSaut)
                    {
                        StartCoroutine(DoubleJump(other, temps));
                        scriptTempsPU.DebutTemps(nbMéthode);
                    }

                    break;
            }
        }
    }

    IEnumerator SlowMo(int temps)
    {
        effet = Instantiate(fx, transform.position, transform.rotation);
        effet.transform.SetParent(transform);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        slowmo = true;

        yield return new WaitForSecondsRealtime(temps);
        Time.timeScale = 1;

        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        slowmo = false;

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;


    }
    IEnumerator ArrêtTemps(Collider autre, int temps)
    {
        effet = Instantiate(fx1, transform.position, transform.rotation);
        effet.transform.SetParent(transform);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        scriptTemps = autre.GetComponent<TimerScript>();
        scriptTemps.compterTemps = false;
        arrêt = true;

        yield return new WaitForSecondsRealtime(temps);

        scriptTemps.compterTemps = true;
        arrêt = false;


        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
    IEnumerator MiniJoueur(Collider autre, int temps)
    {
        effet = Instantiate(fx2, transform.position, transform.rotation);
        effet.transform.SetParent(transform);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        autre.gameObject.transform.localScale *= 0.5f;
        scriptTy = autre.gameObject.GetComponent<JoueurControlleur>();
        autre.attachedRigidbody.mass *= 0.5f;
        mini = true;

        yield return new WaitForSecondsRealtime(temps);
        autre.gameObject.transform.localScale /= 0.5f;

        autre.attachedRigidbody.mass /= 0.5f;
        mini = false;


        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
    IEnumerator DoubleJump(Collider autre, int temps)
    {
        effet = Instantiate(fx3, transform.position, transform.rotation);
        effet.transform.SetParent(transform);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        doubleSaut = true;
        if (PlayerPrefs.GetInt("choixClavier") == 0)
        {
            scriptTy = autre.gameObject.GetComponent<JoueurControlleur>();
            scriptTy.doubleSaut = true;
        }
        else
        {
            scriptPS4 = autre.gameObject.GetComponent<PS4Controller>();
            scriptPS4.doubleSaut = true;
        }
        

        yield return new WaitForSecondsRealtime(temps);

        scriptTy.doubleSaut = false;
        doubleSaut = false;


        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
    public void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }
    #endregion
}
