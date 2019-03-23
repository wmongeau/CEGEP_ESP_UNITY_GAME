using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GénérationCylindres : MonoBehaviour
{
    [SerializeField]
    GameObject cylindre1,cylindre2,cylindre3,cylindre4,cylindre5;

    CylindresDonnées données;
    List<GameObject> Cylindres = new List<GameObject>();
    Vector3 positionIni = new Vector3();
    int nbCylindres;
    float Hauteur;
    GameObject temp;

    System.Random rng = new System.Random();

    void Awake()
    {
        données = new CylindresDonnées();
        Cylindres.Add(cylindre1);
        Cylindres.Add(cylindre2);
        Cylindres.Add(cylindre3);
        Cylindres.Add(cylindre4);
        Cylindres.Add(cylindre5);

        
        positionIni = données.Position;
        nbCylindres = données.NbCylindres;
        Hauteur = données.Hauteur;

        GénérerCylindres();
    }

    private void GénérerCylindres()
    {
        for (int i = 0; i < nbCylindres; i++)
        {
            int chiffre = rng.Next(0, nbCylindres );
            Vector3 positionFinale = new Vector3(positionIni.x, positionIni.y + Hauteur*i, positionIni.z);
            temp=Instantiate(Cylindres[chiffre], positionFinale, Quaternion.AngleAxis(180+i*90,Vector3.up));
            temp.transform.SetParent(gameObject.transform);
            if (i==nbCylindres-1)
            {
                temp.tag = "Final";
            }
        }
    }
}
