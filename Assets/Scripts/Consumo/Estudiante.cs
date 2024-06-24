using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Estudiante
{
    public String Nombre { get; set; }
    public String Correo { get; set; }
    public String CodeCuestionario { get; set; }
    public int Puntaje { get; set; }
    public float ResulEvaluacion { get; set; }
    public String ListaPreTFCorrectas { get; set; }
    public String ListaPreTFIncorrectas { get; set; }
    public String ListaPreOpcionCorrectas { get; set; }
    public String ListaPreOpcionIncorrectas { get; set; }
    public String ListaPreEmpaCorrectas { get; set; }
    public String ListaPreEmpaIncorrectas { get; set; }
    public String FechaInicio { get; set; }
    public String FechaFinal { get; set; }

    public string Juego { get; set; }
}
