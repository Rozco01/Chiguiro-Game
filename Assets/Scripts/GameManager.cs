using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text puntos;

    public int PuntosTotales{get{ return puntosTotales; }}
    private int puntosTotales;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = ": "+ puntosTotales.ToString();
    }

    public void SumaPuntos( int puntosASumar){
        puntosTotales += puntosASumar;

    }
}
