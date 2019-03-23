using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquelletteControlleur : MonoBehaviour
{
    private const float DELAI = 0.5f;
    private Animator animator;
    [SerializeField]
    GameObject Cible;
    [SerializeField]
    float intensité;
    float rayon = 2.5f;
    Rigidbody rbSquellette;
    Rigidbody rbCible;

    public NavMeshAgent agent; 
    float hauteurSquellette;
    Vector3 positionCible;

    void Start()
    {
        agent.updateRotation = false;
        rbCible = Cible.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hauteurSquellette = transform.position.y;
    }
    /// <summary>
    /// Déplace le squelette vers le joueur
    /// </summary>
    void Update()
    {
        positionCible = Cible.transform.position;
        positionCible.y = hauteurSquellette;

       
        agent.SetDestination(Cible.transform.position);
        transform.LookAt(agent.desiredVelocity + transform.position);
        animator.SetBool("estMouvement", true);
        if (Vector3.Distance(transform.position, Cible.transform.position)<0.8)
        {
            transform.LookAt(positionCible);
            animator.SetBool("estMouvement", false);

            StartCoroutine(Delay(DELAI));
        }

    }
    /// <summary>
    /// Délai l'animation d'attaque des squelettes
    /// </summary>
    /// <param name="DELAI">Temps à attendre</param>
    /// <returns></returns>
    IEnumerator Delay(float DELAI)
    {
        animator.SetTrigger("aLattaque");
        yield return new WaitForSeconds(DELAI);
        
        rbCible.AddExplosionForce(intensité, transform.position, rayon, 1f, ForceMode.Impulse);
    }

}
