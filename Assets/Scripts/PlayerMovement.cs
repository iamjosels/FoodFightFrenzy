using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad del jugador
    private Rigidbody2D rb; // Componente Rigidbody2D para mover al jugador
    private Vector2 moveDirection; // Dirección del movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
    }

    void Update()
    {
        // Obtener la entrada de las teclas para el movimiento (WASD o flechas)
        float moveX = Input.GetAxisRaw("Horizontal"); // Movimiento horizontal (A/D o flechas)
        float moveY = Input.GetAxisRaw("Vertical"); // Movimiento vertical (W/S o flechas)

        // Guardar la dirección del movimiento
        moveDirection = new Vector2(moveX, moveY).normalized; // Normalizamos para evitar movimientos más rápidos en diagonal
    }

    void FixedUpdate()
    {
        // Mover al jugador usando el Rigidbody2D
        rb.velocity = moveDirection * moveSpeed; // Aplicamos la velocidad al Rigidbody2D
    }
}

