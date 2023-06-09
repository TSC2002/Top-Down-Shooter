using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    private Rigidbody2D rb2DJugador;

    // Start is called before the first frame update
    void Start()
    {
        rb2DJugador = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2DJugador.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        }
    }
}
