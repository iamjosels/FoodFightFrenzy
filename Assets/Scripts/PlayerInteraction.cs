using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rangoInteraccion = 1.5f; // Distancia a la que el jugador puede interactuar con los ingredientes
    private GameObject ingredienteCercano;
    private Ingrediente ingredienteScript;
    private Ingrediente ingredienteActual; // El ingrediente que el jugador est� sosteniendo
    public Transform areaDePreparacion; // Referencia al plato donde se colocar� el ingrediente
    public int rangoColocacionPlato = 3; // Aumentamos el rango para asegurar que el jugador pueda estar cerca del plato

    void Update()
    {
        // Usamos un raycast para detectar ingredientes cercanos
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, rangoInteraccion, LayerMask.GetMask("Ingrediente")); // Filtramos por la capa "Ingrediente"

        // Debugging: Verificar si el raycast est� funcionando correctamente
        Debug.DrawRay(transform.position, transform.up * rangoInteraccion, Color.red); // Dibuja el raycast en la escena

        if (hit.collider != null)
        {
            Debug.Log("Raycast detectado: " + hit.collider.gameObject.name); // Verifica qu� objeto est� siendo tocado por el raycast

            if (hit.collider.CompareTag("Ingrediente"))
            {
                ingredienteCercano = hit.collider.gameObject;
                ingredienteScript = ingredienteCercano.GetComponent<Ingrediente>();

                // Debugging: Verificar si el ingrediente tiene el tag correcto
                Debug.Log("Ingrediente detectado: " + ingredienteScript.nombreIngrediente);

                // Si el jugador presiona 'E' y no tiene un ingrediente, agarrar el ingrediente
                if (Input.GetKeyDown(KeyCode.E) && ingredienteActual == null)
                {
                    AgarrarIngrediente(ingredienteScript);
                }
            }
        }

        // Si el jugador presiona 'Q' y el ingrediente est� siendo agarrado, colocar el ingrediente en el plato
        if (Input.GetKeyDown(KeyCode.Q) && ingredienteActual != null)
        {
            ColocarIngrediente(ingredienteActual);
        }
    }

    // M�todo para agarrar el ingrediente
    void AgarrarIngrediente(Ingrediente ingrediente)
    {
        ingredienteActual = ingrediente; // Guardamos el ingrediente que est� siendo agarrado
        ingrediente.AgarrarIngrediente(); // Llamamos al m�todo de agarrar el ingrediente
        ingredienteScript.jugador = this.transform; // Asignamos el jugador al ingrediente
        Debug.Log("Ingrediente agarrado: " + ingrediente.nombreIngrediente); // Depuraci�n
    }

    // M�todo para colocar el ingrediente sobre el plato
    void ColocarIngrediente(Ingrediente ingrediente)
    {
        // Verificamos la distancia entre el jugador y el plato
        float distanciaAlPlato = Vector2.Distance(transform.position, areaDePreparacion.position); // Calculamos la distancia entre el jugador y el plato

        // Debugging: Verificar la distancia entre el jugador y el plato
        Debug.Log("Distancia al plato: " + distanciaAlPlato);

        if (distanciaAlPlato <= rangoColocacionPlato)
        {
            ingrediente.ColocarIngrediente(); // Colocar el ingrediente en el plato
            ingredienteActual = null; // Limpiar el ingrediente actual despu�s de colocar
            Debug.Log("Ingrediente colocado sobre el plato: " + ingrediente.nombreIngrediente); // Depuraci�n
        }
        else
        {
            Debug.Log("Est�s demasiado lejos del plato para colocar el ingrediente.");
        }
    }
}










