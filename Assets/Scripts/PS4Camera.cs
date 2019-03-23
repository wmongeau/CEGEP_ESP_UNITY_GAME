using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4Camera : MonoBehaviour {

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
    private void Update()
    {
        if (Input.GetButton("L1") || Input.GetButton("R1")|| Input.GetButton("R2") || Input.GetButton("L2"))
        {
            if (typeCtrl == 0)
            {
                if (Input.GetButton("L1"))
                {
                    currentX -= 1* sensibilité;
                }
                if (Input.GetButton("R1"))
                {
                    currentX += 1 * sensibilité;
                }
                
                currentY += Input.GetAxis("L2") * sensibilité;
                currentY -= Input.GetAxis("R2") * sensibilité;
                tampon += Input.GetAxis("Mouse ScrollWheel") * sensibilité;
            }
            else
            {
                if (Input.GetButton("L1"))
                {
                    currentX += 1 * sensibilité;
                }
                if (Input.GetButton("R1"))
                {
                    currentX -= 1 *sensibilité;
                }
                currentY -= Input.GetAxis("L2") * sensibilité;
                currentY += Input.GetAxis("R2") * sensibilité;
                tampon -= Input.GetAxis("Mouse ScrollWheel") * sensibilité;
            }
        }

    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 1, -tampon);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cam.transform.position = cible.position + rotation * dir;
        transform.LookAt(cible.position);
    }
}
