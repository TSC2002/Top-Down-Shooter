using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigueAlJugador : MonoBehaviour
{
    public bool EstaSiguiendoAlJugador { get; private set; }

    public Vector2 SeDirigeAlJugador { get; private set; }

    [SerializeField]
    private float _DistanciaAlJugador;

    private Transform _Jugador;

    // Start is called before the first frame update
   private void Awake()
    {
        _Jugador = FindAnyObjectByType<MovimientoDelJugador>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 EnemigoParaElJugadorVector = _Jugador.position - transform.position;
        SeDirigeAlJugador = EnemigoParaElJugadorVector.normalized;

        if(EnemigoParaElJugadorVector.magnitude <= _DistanciaAlJugador)
        {
            EstaSiguiendoAlJugador = true;
        }
        else
        {
            EstaSiguiendoAlJugador = false;
        }

    }

}
