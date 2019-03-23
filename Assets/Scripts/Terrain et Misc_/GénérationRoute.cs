using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GénérationRoute : MonoBehaviour
{
    [SerializeField]
    GameObject route;

    [SerializeField]
    GameObject panneau1,panneau2,panneau3;

    [SerializeField]
    float hauteurPanneau,hauteurRoute;

    [SerializeField]
    int nbRoutes;

  
    Vector3 positionIniRoute;
    Vector3 positionIniPanneaux;

    int nbPanneaux;

    float espacementRoute;
    float espacementPanneaux;

    List<GameObject> panneaux = new List<GameObject>();

    RouteDonnées données;


	void Start ()
    {    
        données = new RouteDonnées(nbRoutes);
        positionIniRoute = données.PositionRoute;
        positionIniPanneaux = données.PositionPanneau;
        nbPanneaux = données.NbPanneau;
        espacementRoute = données. EspacementRoute;
        espacementPanneaux = données.EspacementPanneau;

        panneaux.Add(panneau1);
        panneaux.Add(panneau2);
        panneaux.Add(panneau3);

        GénérerRoute();
        GénérerPanneaux();
	}

    private void GénérerRoute()
    {
        for (int i = 0; i < nbRoutes; i++)
        {
            Vector3 positionFinale = new Vector3(positionIniRoute.x, hauteurRoute, positionIniRoute.z+espacementRoute*i);
            Instantiate(route, positionFinale, Quaternion.identity);
        }
    }

    private void GénérerPanneaux()
    {
           
        for (int i = 0; i < nbPanneaux; i++)
        {
            Vector3 positionFinale = new Vector3(positionIniPanneaux.x, hauteurPanneau, positionIniPanneaux.z+espacementPanneaux*i);
            Instantiate(panneaux[i], positionFinale, Quaternion.identity);
        }
    }
	
	
}
