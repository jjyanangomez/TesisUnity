using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Informacion
{
    public bool status { get; set; }
    public Cuestionario Cuestionario { get; set; }
}
[Serializable]
public class Cuestionario 
{
    public string NombreCuestionario { get; set; }
    public string CodigoCuestionario { get; set; }
    public int NumPreguntas { get; set; }
    public double ValorPregunta { get; set; }
    public int ValorCuestionario { get; set; }
    public string EstadoCuestionario { get; set; }
    public Banco Banco { get; set; }
}
[Serializable] 
public class Banco
{
    public string Tema { get; set; }
    public string Asignatura { get; set; }
    public string Id { get; set; }
    /*public List<PreguntasTF> PreguntasTF { get; set; }
    public List<PreguntasOpcion> PreguntasOpcion { get; set; }
    public List<PreguntasEmparejamiento> PreguntasEmparejamiento { get; set; }*/
    public PreguntasTF[] PreguntasTF { get; set; }
    public PreguntasOpcion[] PreguntasOpcion{ get; set; }
    public PreguntasEmparejamiento[] PreguntasEmparejamiento { get; set; }
}
[Serializable]
public class PreguntasTF
{
    public int IdBancoTrueFalse { get; set; }
    public string Pregunta { get; set; }
    public string Respuesta { get; set; }
    public string RetroAlimentacion { get; set; }
}

[Serializable]
public class PreguntasOpcion
{
    public int IdBancoOpcion { get; set; }
    public string Pregunta { get; set; }
    public string Respuesta1 { get; set; }
    public string OpValida1 { get; set; }
    public string Respuesta2 { get; set; }
    public string OpValida2 { get; set; }
    public string Respuesta3 { get; set; }
    public string OpValida3 { get; set; }
    public string Respuesta4 { get; set; }
    public string OpValida4 { get; set; }
    public string RetroAlimentacion { get; set; }
}


[Serializable]
public class PreguntasEmparejamiento
{
    public int IdBancoEmpar { get; set; }
    public string Pregunta { get; set; }
    public string Enunciado1 { get; set; }
    public string ResPrimerEnunciado { get; set; }
    public string Enunciado2 { get; set; }
    public string ResSegundoEnunciado { get; set; }
    public string Enunciado3 { get; set; }
    public string ResTercerEnunciado { get; set; }
    public string RetroAlimentacion { get; set; }
}

[Serializable] 

public class seguridad
{
    public bool status { get; set; }
    public string message { get; set; }
}


[Serializable]

public class ResultadosEstudiantes
{
    public bool status { get; set; }
    public List<Resultados> Resultados { get; set; }
}

[Serializable]

public class Resultados
{
    public int IdReporte { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public float ResultadoEva { get; set; }
    public string Puntaje { get; set; }
    public string Duracion { get; set; }
}