using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteDonnées
{
    const float Xroute = 26.328f; //à vérifier
    const float Yroute = -5.168f;//À vérifier selon le terrain généré procéduralement
    const float Zroute = -228f;  //à vérifier

    const float Xpanneau = 26.603f; //à vérifier
    const float Ypanneau = -3.708f;//À vérifier selon le terrain généré procéduralement
    const float Zpanneau = -66.50f;  //à vérifier

    private Vector3 positionRoute;
    public Vector3 PositionRoute
    {
        get { return positionRoute; }
        private set
        {
            positionRoute =value;
        }
    }

    private Vector3 positionPanneau;
    public Vector3 PositionPanneau
    {
        get { return positionPanneau;}
        private set
        {
            positionPanneau =value;
        }
    }

    private int nbRoutes;
    public int NbRoutes
    {
        get { return nbRoutes; }
        private set
        {
            nbRoutes = value;  //Le nombre de routes à instancier
        }
    }

    private int nbPanneau;
    public int NbPanneau
    {
        get { return nbPanneau; }
        private set
        {
            nbPanneau = value;  //Le nombre de routes à instancier
        }
    }

    private float espacementPanneau;
    public float EspacementPanneau
    {
        get { return espacementPanneau; }
        private set
        {
            espacementPanneau= value; //l'espacement entre chaque panneau en Z
        }
    }

    private int espacementRoute;
    public int EspacementRoute
    {
        get { return espacementRoute; }
        private set
        {
            espacementRoute = value; //l'espacement entre chaque panneau en Z
        }
    }

    public RouteDonnées(int nbRoutes )
    {
        PositionRoute = new Vector3(Xroute,Yroute,Zroute);
        PositionPanneau = new Vector3(Xpanneau,Ypanneau,Zpanneau);
        NbRoutes = nbRoutes;
        NbPanneau = 3;
        EspacementPanneau = 22.5f;
        EspacementRoute = 5;
    }
}
