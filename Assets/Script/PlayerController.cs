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
    public GameObject pausa;
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
        pausa.SetActive(false);
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
    }

    private void Jump(bool j)
    {       
        rb.AddForce(Vector2.up * fuerzaSalto);
        Debug.Log("salto");
    }

   
}
