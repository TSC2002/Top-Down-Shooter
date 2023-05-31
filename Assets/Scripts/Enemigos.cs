using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField]
    private float _velocidad;

    [SerializeField]
    private float _rotacionvelocidad;

    private Rigidbody2D _rigidbody;
    private SigueAlJugador _sigueAlJugador;
    private Vector2 Direccion;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _sigueAlJugador = GetComponent<SigueAlJugador>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ActualizarLaDireccionDelObjetivo();
        DireccionDelObjetivo();
        ActualizarLaVelocidad();
    }

    private void ActualizarLaDireccionDelObjetivo()
    {
        if(_sigueAlJugador.EstaSiguiendoAlJugador)
        {
            Direccion = _sigueAlJugador.SeDirigeAlJugador;
        }
        else
        {
            Direccion = Vector2.zero;
        }
    }

    private void DireccionDelObjetivo()
    {
        if (Direccion == Vector2.zero)
        {
            return; 
        }

        Quaternion RotacionDeOBjetivos = Quaternion.LookRotation(transform.forward, Direccion);
        Quaternion rotacion = Quaternion.RotateTowards(transform.rotation, RotacionDeOBjetivos, _rotacionvelocidad * Time.deltaTime);

        _rigidbody.SetRotation(rotacion);
    }

    private void ActualizarLaVelocidad()
    {
        if(Direccion == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * _velocidad;
        }
    }
}
