using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeAttiranteControlleur : MonoBehaviour
{


    Rigidbody ty;
    bool estAttiré;
    [SerializeField]
    float facteur;


    Vector3 direction;
    Vector3 posPlateforme;
    Vector3 platformeUp;
    Vector3 tyUp;
    Quaternion rotationCible;
    float forceAttraction;
 

    void Start()
    {
        estAttiré = false;
        posPlateforme = transform.position;
    }

/// <summary>
/// Calcul les différents vecteurs de forces nécessaires et les apppliques
/// </summary>
    void FixedUpdate()
    {
        if (estAttiré)
        {
            direction = CalculerDirectionAttraction();
            forceAttraction = facteur;
            platformeUp = -direction;
            tyUp = ty.transform.up;
            rotationCible = Quaternion.FromToRotation(tyUp, platformeUp) * ty.transform.rotation;
            ty.transform.rotation = Quaternion.Slerp(ty.transform.rotation, rotationCible, 10 * Time.deltaTime);
            ty.AddForce(direction * forceAttraction, ForceMode.Acceleration);
        }
    }
    /// <summary>
    /// Vérifie si l'objet dans le triger est le joueur 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ty")
        {
            ty = other.GetComponent<Rigidbody>();
            ty.useGravity = false;
            estAttiré = true;
        }
    }
    /// <summary>
    /// Retourne le joueur à sa rotation originale lorsqu'il quitte le trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ty")
        {
            ty = other.GetComponent<Rigidbody>();
            ty.transform.rotation = Quaternion.identity;
            ty.velocity = new Vector3(0, 0, 0);
            ty.useGravity = true;
            estAttiré = false;
        }
    }

    /// <summary>
    /// Calcul la direction de la force à appliquée
    /// </summary>
    /// <returns>Retourne un vecteur 3</returns>
    private Vector3 CalculerDirectionAttraction()
    {
        Vector3 directionForce = (posPlateforme - ty.position).normalized;
        return directionForce;
    }
}
