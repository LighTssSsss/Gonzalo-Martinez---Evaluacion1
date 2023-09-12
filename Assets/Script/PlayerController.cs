using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool puedoSaltar;
    
    private void OnEnable()
    {
        InputManager.OnMovement += HandleMovement;
    }

    private void OnDisable()
    {
        InputManager.OnMovement -= HandleMovement;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(input.x,0);
        rb.MovePosition(rb.position +(velocity * Time.fixedDeltaTime * speed));
    }

    private void HandleMovement(Vector2 move)
    {
        input = move;
    }

    private void Jump()
    {
        
        Debug.Log("salto");
    }
}
