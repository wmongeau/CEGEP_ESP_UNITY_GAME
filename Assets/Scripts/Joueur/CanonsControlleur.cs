using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonsControlleur : MonoBehaviour
{
    [SerializeField]
    GameObject Cible;

    [SerializeField]
    GameObject TowerTop;

    [SerializeField]
    float intensité;

    [SerializeField]
    GameObject boulet;

    [SerializeField]
    Transform origine;

    [SerializeField]
    float delai;

    Rigidbody rbCible;
    Rigidbody rbBoulet;

    float hauteurTour;
    float compteur = 0;

    Vector3 positionCible;
    Vector3 positionIniBoulet;
    Vector3 trajectoire;

    Vector3 positionIni;
    Vector3 positionDeplacé;
     
    int intervalle = 0;

    System.Random rng = new System.Random();

    void Start ()
    {
        hauteurTour = TowerTop.transform.position.y;
	}
    /// <summary>
    /// Ajuste la rotation du canon pour qu'il vise le joueur
    /// </summary>
    void Update()
    {
        positionDeplacé = Cible.transform.position;
        trajectoire = TrouverTrajectoire(positionIni,positionDeplacé);
        positionIniBoulet = origine.position;
        positionCible = Cible.transform.position;
        positionCible.y = hauteurTour;

        TowerTop.transform.LookAt(positionCible);
        if (compteur+delai > 5&& (Cible.transform.position-transform.position).magnitude>15)
        {
            GameObject bouletClone = Instantiate(boulet, positionIniBoulet, Quaternion.identity);
            Rigidbody rb = bouletClone.GetComponent<Rigidbody>();
            rb.AddForce((trajectoire-transform.position) * intensité,ForceMode.Acceleration);
            compteur = 0;
        }
        else compteur += Time.deltaTime;

        positionIni = Cible.transform.position;
    }
    /// <summary>
    /// Trouve la cible à viser pour qu'elle soit dans la trajectoire du joueur
    /// </summary>
    /// <param name="position1"></param>
    /// <param name="position2"></param>
    /// <returns></returns>
    private Vector3 TrouverTrajectoire(Vector3 position1,Vector3 position2)
    {
        return (position2 - position1)*50 + Cible.transform.position;
    }
}
