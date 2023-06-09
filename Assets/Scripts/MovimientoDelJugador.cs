using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
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

=======
using UnityEngine.InputSystem;
public class MovimientoDelJugador : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float VelocidadDeRotacion;

    private Rigidbody2D rb2D;
    private Vector2 MovimientoPlayer;

    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RoteteInDirectionOfImput();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            MovimientoPlayer,
            ref movementInputSmoothVelocity,
            0.1f);

        rb2D.velocity = MovimientoPlayer * speed;
    }

    private void RoteteInDirectionOfImput()
    {
        if (MovimientoPlayer != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, VelocidadDeRotacion * Time.deltaTime);

            rb2D.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        MovimientoPlayer = inputValue.Get<Vector2>();
>>>>>>> 01e0b4dac2cbdf08a35e894f41bfc70947839a99
    }
}
