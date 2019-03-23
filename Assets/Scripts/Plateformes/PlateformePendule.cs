using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformePendule : MonoBehaviour
{
    float compteur = 0;
    Transform objetCollision;
    Transform parent;
    private void Start()
    {
        parent = transform;
    }
    /// <summary>
    ///Déplace la plateforme
    /// </summary>
    void Update()
    {
      
        parent.Translate(Vector3.forward * Mathf.Cos(Time.time) * Time.deltaTime / 4);
        if (compteur < Mathf.PI * 2 && compteur > Mathf.PI)
        {
            parent.Translate(Vector3.down * Mathf.Cos(compteur) * Time.deltaTime / 4);
            compteur = 0;
        }
        else
        {
            parent.Translate(Vector3.up * Mathf.Cos(compteur) * Time.deltaTime / 4);
        }
        compteur += Time.deltaTime;

    }
    /// <summary>
    /// Si l'objet dans le trigger est le joueur, son parent devient la plateforme
    /// </summary>
    /// <param name="col"></param>
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ty")
        {
            Transform tyTransform = col.gameObject.transform;
            tyTransform.SetParent(parent,true);
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
            Transform tyTransform = other.gameObject.transform;
            tyTransform.SetParent(null);
        }
    }
}
