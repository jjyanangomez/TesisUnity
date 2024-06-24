using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseDatos", menuName = "Inventario/Lista", order = 1)]
public class DataBase : ScriptableObject
{
    [System.Serializable]
    public struct OjetosInventario
    {
        public string nombre;
        public int Id;
        public Sprite icono;
        public Tipo tipo;
        public bool acumulable;
        public string Descripcion;
        public string Void;
    }
    public enum Tipo
    {
        consumible,
        equipable,
        entregable
    }
    public OjetosInventario[] baseDatos;
}
