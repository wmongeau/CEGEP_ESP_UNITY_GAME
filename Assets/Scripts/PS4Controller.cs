using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS4Controller : MonoBehaviour
{
    [HideInInspector]
    public float vitesse = 7;

    //[HideInInspector]
    public float saut = 5;

    [HideInInspector]
    public bool doubleSaut = false;

    public LayerMask solLayer;
    public BoxCollider col;

    private float currentX = 0.0f;
    private float tampon = 10.0f;
    private int nbSaut;
    Vector2 input;
    Vector3 direction;

    Quaternion rotationCible;
    Animator anim;

    public Personnages positionTy;

    Rigidbody rb;

    private void Start()
    {
        positionTy = new Personnages(gameObject.transform.position, 0);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        nbSaut = 2;
    }
    private void Update()
    {
        if (AuSol())
        {
            nbSaut = 2;
        }
        GetInput();
        Tourner();
        if ((Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1))
        {
            anim.SetBool("estCourir", false);
            anim.SetBool("estStrafeRight", false);
            anim.SetBool("estStrafeLeft", false);
            anim.SetBool("estReculons", false);
            return;
        }
        CalculerDirection();
        Déplacer();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("X"))  
        {
            Debug.Log("allo");
            Sauter();
        }
        if (input.x == 0 && input.y == 1)
        {
            anim.SetBool("estCourir", true);
            anim.SetBool("estStrafeRight", false);
            anim.SetBool("estStrafeLeft", false);
            anim.SetBool("estReculons", false);
        }
        else if (input.x == 0 && input.y == -1)
        {
            anim.SetBool("estCourir", false);
            anim.SetBool("estStrafeRight", false);
            anim.SetBool("estStrafeLeft", false);
            anim.SetBool("estReculons", true);
        }
        else if (input.x == 1 && input.y == 0)
        {
            anim.SetBool("estCourir", false);
            anim.SetBool("estStrafeRight", true);
            anim.SetBool("estStrafeLeft", false);
            anim.SetBool("estReculons", false);
        }
        else if (input.x == -1 && input.y == 0)
        {
            anim.SetBool("estCourir", false);
            anim.SetBool("estStrafeRight", false);
            anim.SetBool("estStrafeLeft", true);
            anim.SetBool("estReculons", false);
        }
    }

    void CalculerDirection()
    {
        direction = ((input.x * transform.right) + (input.y * transform.forward)).normalized;
    }

    void Tourner()
    {
        Vector3 nouvelleRotation = transform.eulerAngles;
        nouvelleRotation.y = Camera.main.transform.eulerAngles.y;
        transform.eulerAngles = nouvelleRotation;
    }
    void Déplacer()
    {
        transform.position += direction * vitesse * Time.deltaTime;
    }
    void Sauter()
    {
        if (AuSol())
        {
            rb.AddForce((transform.up) * saut, ForceMode.Impulse); 
            nbSaut--;
        }
        else if (nbSaut > 1 && doubleSaut)
        {
            rb.AddForce((transform.up) * saut, ForceMode.Impulse);
            nbSaut--;
        }

    }
    private bool AuSol()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.size.x * .45f, solLayer);
    }
}
