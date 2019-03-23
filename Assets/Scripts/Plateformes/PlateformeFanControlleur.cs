using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeFanControlleur : MonoBehaviour {

    Rigidbody ty;
    bool estVolant;
    [SerializeField]
    float force;

	void Start () {
        estVolant = false;
	}
	
	/// <summary>
    /// Applique une force vers le haut sur l'objet qui est sur la plateforme
    /// </summary>
	void LateUpdate () {
        if (estVolant)
        {
            ty.AddForce(Vector3.up * force);
        }
	}
    /// <summary>
    /// Vérifie si l'objet dans le trigger est le joueur
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ty")
        {
            ty = other.GetComponent<Rigidbody>();
            estVolant = true;
        }
    }
    /// <summary>
    /// Arrête les forces lorsque l'objet quitte le trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        estVolant = false;
    }
}
