using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaSaltando : MonoBehaviour
{
    public static bool EstaEnElSuelo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EstaEnElSuelo = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EstaEnElSuelo = false;
    }

}
