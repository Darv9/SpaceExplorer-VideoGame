using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDanno;

    private float tiempoSiguienteDanno;

    private void OnTriggerStay2D(Collider2D other)
    {
       if(tiempoSiguienteDanno<=0)
        {
            other.GetComponent<CombateJudador>().TomarDano(5);
            tiempoSiguienteDanno = tiempoEntreDanno;
        }
    }
}
