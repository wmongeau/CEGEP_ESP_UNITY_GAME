using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlleur : MonoBehaviour {

    public Transform cible;

    private Camera cam;

    private float tampon = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    [SerializeField]
    public float sensibilité = 4.0f;

    [HideInInspector]
    public int typeCtrl = 0;

    private const float ANGLE_Y_MIN = 0.0f;
    private const float ANGLE_Y_MAX = 50.0f;


    private void Start()
    {
        cam = Camera.main;
    }
    /// <summary>
    /// Ajuste la position de la caméra baser sur la position de la souris 
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (typeCtrl==0)
            {
                currentX += Input.GetAxis("Mouse X") * sensibilité;
                currentY -= Input.GetAxis("Mouse Y") * sensibilité;
                tampon -= Input.GetAxis("Mouse ScrollWheel") * sensibilité;
            }
            else
            {
                currentX -= Input.GetAxis("Mouse X") * sensibilité;
                currentY -= Input.GetAxis("Mouse Y") * sensibilité;
                tampon -= Input.GetAxis("Mouse ScrollWheel") * sensibilité;
            }
        }

    }

    /// <summary>
    /// Ajsute la rotation de la caméra baser sur la position de la souris
    /// </summary>
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 1, -tampon);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cam.transform.position = cible.position + rotation * dir;
        transform.LookAt(cible.position);
    }
}
