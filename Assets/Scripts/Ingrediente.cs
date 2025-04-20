using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public string nombreIngrediente; // Nombre del ingrediente (ej: "Pan Arriba")
    public bool estaAgarrado = false; // Si el ingrediente está siendo sostenido por el jugador
    public Transform areaDePreparacion; // Referencia al plato donde se colocará el ingrediente
    public Transform jugador; // Referencia al jugador para seguirlo cuando se agarra el ingrediente
    private Vector3 offset; // Posición relativa del ingrediente con respecto al jugador
    public Vector3 posicionSujecion; // La posición en la que el ingrediente se debe quedar cerca del jugador

    private void Start()
    {
        // Definir el offset como la distancia entre el jugador y el ingrediente, pero más cercano
        offset = new Vector3(0.2f, 0.5f, 0); // Ajusta estos valores para colocar el ingrediente más cerca
    }

    void Update()
    {
        // Si el ingrediente está agarrado, seguir la posición del jugador
        if (estaAgarrado)
        {
            // Mantener el ingrediente a una distancia relativa del jugador
            transform.position = jugador.position + offset; // Mantener el ingrediente cerca del jugador
        }
    }

    // Método para agarrar el ingrediente
    public void AgarrarIngrediente()
    {
        estaAgarrado = true;
        // Desactivar el collider para que no colisione mientras lo lleva
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("Ingrediente agarrado: " + nombreIngrediente);
    }

    // Método para colocar el ingrediente en el plato cuando se suelta
    public void ColocarIngrediente()
    {
        estaAgarrado = false;
        // Colocar el ingrediente en el plato
        transform.position = areaDePreparacion.position;
        GetComponent<Collider2D>().enabled = true; // Habilitar el collider nuevamente
        Debug.Log("Ingrediente colocado sobre el plato: " + nombreIngrediente);
    }

    // Restablecer la posición original si el jugador no coloca el ingrediente
    public void RestablecerIngrediente()
    {
        estaAgarrado = false;
        transform.position = jugador.position + offset;
        GetComponent<Collider2D>().enabled = true;
    }
}


