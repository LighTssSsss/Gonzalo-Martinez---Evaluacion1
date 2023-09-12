using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private bool jump;
    [SerializeField] private float speed;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool puedoSaltar;
    [SerializeField] private bool salto;
    [SerializeField] private bool ejecuta;

    [SerializeField] private FMODUnity.StudioEventEmitter pasos;
    [SerializeField] private FMODUnity.StudioEventEmitter saltos;
    [SerializeField] private FMODUnity.StudioEventEmitter tocaSuelo;
    
    private void OnEnable()
    {
        InputManager.OnMovement += HandleMovement;
        InputManager.OnJump += Jump;
 
    }

    private void OnDisable()
    {
        InputManager.OnMovement -= HandleMovement;
        InputManager.OnJump -= Jump;
 
    }


    // Start is called before the first frame update
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(input.x,0);
        rb.position += ((velocity * Time.fixedDeltaTime * speed));

       
    }

    private void HandleMovement(Vector2 move)
    {
        input = move;
       
        
        if(move.magnitude != 0 && !ejecuta)
        {
            ejecuta = true;
            pasos.Play();

        }

        if(move.magnitude == 0 && ejecuta)
        {
            pasos.Stop();
            ejecuta = false;
       
        }
      
    }

    private void Jump(bool j)
    {       
        if(puedoSaltar == true)
        {
            rb.AddForce(Vector2.up * fuerzaSalto);
            salto = true;
            saltos.Play();
            //Debug.Log("salto");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Piso" && salto == false)
        {
            puedoSaltar = true;
            salto = false;
            //Debug.Log("Puede Saltar");
        }

        if(collision.gameObject.tag == "Piso"  && salto == true)
        {
           // Debug.Log("Sonido Piso");
            tocaSuelo.Play();
            puedoSaltar = true;
            salto = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            puedoSaltar = false;
            salto = true;
            //Debug.Log("salto");
        }
    }


}


   



