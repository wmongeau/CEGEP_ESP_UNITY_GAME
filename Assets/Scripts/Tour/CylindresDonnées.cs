using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylindresDonnées
{
    const float X = 30.2f; //à vérifier
    const float Y = 24.8f;//À vérifier selon le terrain généré procéduralement
    const float Z = 33.2f;  //à vérifier

    private Vector3 position;
    public Vector3 Position
    {
        get { return position; }
        private set
        {
            position = value;
        }
    }

    private float hauteur;
    public float Hauteur
    {
        get { return hauteur; }
        private set
        {
            hauteur = value; 
        }
    }

    private int nbCylindres;
    public int NbCylindres
    {
        get { return nbCylindres; }
        private set
        {
            nbCylindres = value;  
        }
    }

    public CylindresDonnées()
    {
        NbCylindres = 3;//Le nombre de cylindres à instancier
        Hauteur = 20f; //La demi_hauteur d'un cylindre
        Position = new Vector3(X, Y, Z);
    }
}
