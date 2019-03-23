using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class Personnages 
{
    Vector3 positionIni;
    /// <summary>
    /// Vecteur 3 qui représente la position initiale du joueur
    /// </summary>
    public Vector3 PositionIni
    {
        get { return positionIni; }
        set { positionIni = value; }
    }

    float tempsIni;
    /// <summary>
    /// Float qui représente le temps initial du joueur
    /// </summary>
    public float TempsIni
    {
        get { return tempsIni ; }
        set { tempsIni = value; }
    }

    public Personnages(Vector3 position, float temps)
    {
        PositionIni = position;
        TempsIni = temps;
    }

}
