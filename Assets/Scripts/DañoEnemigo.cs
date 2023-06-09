using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Jugador"))
        {
            Debug.Log("Daño al jugador");
            Destroy(collision.gameObject);
        }
    }





}
