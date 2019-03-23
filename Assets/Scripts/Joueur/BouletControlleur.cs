using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouletControlleur : MonoBehaviour
{

    [SerializeField]
    GameObject explosionFX;

    float rayon = 5.0f;
    Vector3 forceExplosion;
    GameObject exp;

    [SerializeField]
    float intensité = 1;

    [SerializeField]
    float hauteur = 5;

    /// <summary>
    /// Ajoute une explosion lorsque le boulet entre en collison avec un objet
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        exp=Instantiate(explosionFX, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, rayon);
        foreach (Collider objet in colliders)
        {
            forceExplosion = CalculerForce(objet.transform.position, transform.position);
            Rigidbody rb = objet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(intensité, transform.position, rayon,1f,ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
        Destroy(exp,10);
    }
    /// <summary>
    /// Calcul la force à appliquer lors de l'explosion
    /// </summary>
    /// <param name="positionCible">Position de la cible</param>
    /// <param name="positiopnProjectile">Position du boulet</param>
    /// <returns></returns>
    private Vector3 CalculerForce(Vector3 positionCible,Vector3 positiopnProjectile)
    {
        Vector3 direction = positionCible - positiopnProjectile;
        direction = new Vector3(direction.x, hauteur, direction.z)*intensité;
        return direction;
    }

}