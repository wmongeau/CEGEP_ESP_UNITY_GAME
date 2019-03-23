using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformesSpeciales : MonoBehaviour
{
    [SerializeField]
    int numéroMéthode;

    bool estTombante = false;
    bool estExplosive = false;
    bool estExplosée =false;
    float vitesseDescente = 0;
    float compteur = 0;
    float x;
    float y;
    float rouge = 0;
    const float INTENSITE = 0.0000005f;

    Vector3 positionIni;
    Quaternion rotationIni;
    Renderer couleur;
    Color couleurIni;
 
    private void Start()
    {
        positionIni = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rotationIni = transform.localRotation;
        couleur = GetComponent<Renderer>();
        couleurIni = couleur.material.color;
    }
    /// <summary>
    /// Si l'objet dans le trigger est le joueur, commencer les effets des plateformes.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ty")
        {
            switch (numéroMéthode)
            {
                case 1:
                     estTombante=true;
                    break;
                case 2:
                    estExplosive = true;
                    break;
            }         
        }
    }

    /// <summary>
    /// Selon le cas, fait "exploser" ou tomber la plateforme
    /// </summary>
    void Update ()
    {
        if (estTombante)
        {
            if (compteur < 3)
            {
                transform.localRotation = Quaternion.Euler(rotationIni.x,rotationIni.eulerAngles.y, Random.Range(-5f, 5f));
            }
            
            if (compteur >= 4)
            {
                if (compteur <= 13)
                {
                    vitesseDescente += Time.deltaTime / 15;
                    transform.position = new Vector3(transform.position.x, transform.position.y - vitesseDescente, transform.position.z);
                }
                else
                {
                    estTombante = false;
                    vitesseDescente = 0;
                    transform.position = positionIni;
                    compteur = 0;
                }
            }
            compteur += Time.deltaTime;
        }
        if (estExplosive)
        {
            if (compteur < 3)
            {
                rouge = Mathf.PingPong(Time.time*2f, 1);
                couleur.material.color = new Color(rouge, 0, 0);
            }
            if (compteur >= 3)
            {
                if (!estExplosée)
                {
                    transform.position = new Vector3(0,-200,0);
                    estExplosée = true;
                }
                if (compteur >= 13)
                {
                    estExplosive = false;
                    estExplosée = false;
                    transform.position = positionIni;
                    compteur = 0;
                    rouge = 0;
                    couleur.material.color = couleurIni;
                }
            }
            compteur += Time.deltaTime;
        }
    }
}
