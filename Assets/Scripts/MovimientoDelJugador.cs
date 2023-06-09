using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoDelJugador : MonoBehaviour
{
    public float CaminarRapido;

    public float SaltarRapido;

    Rigidbody2D rb2D;

    public Text Puntaje;

    int contador;

    public Text Victoria;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        contador = contador + 1;
        Puntaje.text = "Naranjas: " + contador;
        if (contador >= 17)
        {
            Victoria.gameObject.SetActive(true);
        }
    }

    public void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        contador = 0;
        Puntaje.text = "Naranjas: " + contador;
        Victoria.gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-CaminarRapido, rb2D.velocity.y);
        }

        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(CaminarRapido, rb2D.velocity.y);
        }

        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKey("space") && EstaSaltando.EstaEnElSuelo)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, SaltarRapido);
        }

    }
}
