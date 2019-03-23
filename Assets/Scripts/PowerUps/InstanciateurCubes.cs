using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InstanciateurCubes : MonoBehaviour
{

    [SerializeField]
    int nbPowerUps;


    [SerializeField]
    GameObject powerUp;


    GameObject powerUpInstancier;
    Transform[] tours;
    Transform[] plateformes;
    List<Transform> listPlateformes = new List<Transform>();
    System.Random rng;



    void Start()
    {
        rng = new System.Random();
        GetPlateformes();
        InstancierCubes();
    }

    void GetPlateformes()
    {

        tours = gameObject.GetComponentsInParent<Transform>();
        foreach (Transform t in tours)
        {
            plateformes = t.GetComponentsInChildren<Transform>();
            foreach (Transform p in plateformes)
            {
                listPlateformes.Add(p);
            }
        }
    }
    void InstancierCubes()
    {
        for (int i = 0; i < nbPowerUps; i++)
        {
            int chiffre = rng.Next(0, listPlateformes.Count);
            if (!listPlateformes[chiffre].CompareTag("No PowerUp"))
            {
                Vector3 position = new Vector3(listPlateformes[chiffre].transform.position.x, listPlateformes[chiffre].transform.position.y + 0.5f, listPlateformes[chiffre].transform.position.z);
                powerUpInstancier = Instantiate(powerUp, position, Quaternion.identity);
                powerUpInstancier.transform.SetParent(transform);
                listPlateformes[chiffre].tag = "No PowerUp";
                if (chiffre == listPlateformes.Count - 3)
                {
                    listPlateformes[chiffre].GetComponent<Collider>().enabled = true;
                }
                listPlateformes.Remove(listPlateformes[chiffre]);
            }
        }
    }

}
