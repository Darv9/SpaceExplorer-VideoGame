using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJudador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;

    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDano(float dano)
    {
        vida -= dano;
        barraDeVida.CambiarVidaActual(vida);

        if (vida <=0) {
            barraDeVida.CambiarVidaActual(vida);
            Destroy(gameObject);
        }
    }

}
