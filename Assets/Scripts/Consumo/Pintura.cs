using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Pintura
{
    public int id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Tema { get; set; }
    public string Tecnica { get; set; }
    public string Dimensiones { get; set; }
    public string Ubicacion { get; set; }
    public string Anio { get; set; }
    public string Pagina { get; set; }


    public Pintura(int id, string Titulo, string Autor, string Tema, string Tecnica, string Dimensones, string Ubicacion, string Anio, string Pagina)
    {
        this.id = id;
        this.Titulo = Titulo;
        this.Autor = Autor;
        this.Tema = Tema;
        this.Tecnica = Tecnica;
        this.Dimensiones = Dimensiones;
        this.Ubicacion = Ubicacion;
        this.Anio = Anio;
        this.Pagina = Pagina;
    }
}
[Serializable]
public class BaseDatos
{
    public List<Pintura> Pinturas;
}

[Serializable]
public class BaseDatosAux
{
    public Pintura[] Pinturas;
}
