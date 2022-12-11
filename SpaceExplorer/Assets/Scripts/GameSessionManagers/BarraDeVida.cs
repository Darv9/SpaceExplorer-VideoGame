using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {

    }



    public void CambiarVidaMaxima(float vidaMaxima)
    {
        _slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        _slider.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        _slider = GetComponent<Slider>();
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}




