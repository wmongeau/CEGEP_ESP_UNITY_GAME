using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouvante : MonoBehaviour
{
    /// <summary>
    /// Déplace la plateforme
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.forward * Mathf.Cos(Time.time) * Time.deltaTime / 4);
    }
    /// <summary>
    /// Vérifie que l'objet dans le trigger est le joueur est fait sorte que son parent est la plateforme
    /// </summary>
    /// <param name="col"></param>
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ty")
        {
            col.transform.SetParent(transform,true);
        }

    }
    /// <summary>
    /// Enlève le parent de l'objet
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "ty")
        {
            other.gameObject.transform.SetParent(null);
        }

    }
}
