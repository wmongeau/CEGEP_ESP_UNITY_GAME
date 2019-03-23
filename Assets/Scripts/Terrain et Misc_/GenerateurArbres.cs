using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurArbres : MonoBehaviour
{

    [SerializeField]
    GameObject arbre1, arbre2, arbre3, arbre4;

    [SerializeField]
    float hauteur;

    [SerializeField]
    int nbArbres;

    [SerializeField]
    int nbRoutes;

    int borneX1Min, borneX2Min, borneYMin, borneX1Max, borneX2Max, borneYMax;


    List<GameObject> Arbres = new List<GameObject>();

    RouteDonnées donnéesRoute;




    System.Random rng = new System.Random();

    void Start()
    {
    
        donnéesRoute = new RouteDonnées(nbRoutes);
        Arbres.Add(arbre1);
        Arbres.Add(arbre2);
        Arbres.Add(arbre3);
        Arbres.Add(arbre4);

        FaireBornes();
        GénérerArbres();
    }

    private void FaireBornes()
    {
        borneX1Min = (int)donnéesRoute.PositionRoute.x - 600;
        borneX1Max = (int)donnéesRoute.PositionRoute.x - 15;
        borneYMin = (int)donnéesRoute.PositionRoute.z - 10;
        borneYMax = (int)donnéesRoute.PositionRoute.z + donnéesRoute.NbRoutes*donnéesRoute.EspacementRoute+150;
        borneX2Min = (int)donnéesRoute.PositionRoute.x + 22;
        borneX2Max = (int)donnéesRoute.PositionRoute.x + 600;

    }

    private void GénérerArbres()
    {
        for (int i = 0; i < nbArbres; i++)
        {
            int chiffre = rng.Next(0, Arbres.Count);
            Vector3 position1 = new Vector3(rng.Next(borneX1Min, borneX1Max), hauteur, rng.Next(borneYMin, borneYMax));
            Vector3 position2 = new Vector3(rng.Next(borneX2Min, borneX2Max), hauteur, rng.Next(borneYMin, borneYMax));
            Instantiate(Arbres[chiffre], position1, Quaternion.identity);
            Instantiate(Arbres[chiffre], position2, Quaternion.identity);
        }
    }
}
