using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeCirculaire : MonoBehaviour {

    Transform objetCollision;
    /// <summary>
    /// Fait boujer la plateforme en cercle
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.forward * Mathf.Cos(Time.time) * Time.deltaTime / 4);
        transform.Translate(Vector3.up * Mathf.Sin(Time.time) * Time.deltaTime / 4);
        transform.Translate(Vector3.right * Mathf.Cos(Time.time) * Time.deltaTime / 4);
    }
    /// <summary>
    /// Fait en sorte que le parent de l'objet qui entre dans le trigger est la plateforme
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        objetCollision = col.GetComponent<Transform>();
        objetCollision.SetParent(transform);
    }
    /// <summary>
    /// Enlève le parent de l'objet lorsqu'il quitte le trigger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        objetCollision = other.GetComponent<Transform>();
        objetCollision.SetParent(null);
    }
}
