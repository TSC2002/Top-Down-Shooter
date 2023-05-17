using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
}
