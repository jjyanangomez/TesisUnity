using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseMisiones", menuName = "NuevaBMisiones", order = 1)]
public class BaseMisiones : ScriptableObject
{
    [System.Serializable]
    public struct mision
    {
        public string nombre;
        public string descripcion;
        public int id;
        public QuestType type;

        [System.Serializable]
        public enum QuestType
        {
            Recolectar,
            Matar,
            Entregar
        }

        [Header("Misiones de Recoleccion")]
        public bool SeQuedaConItems;
        public ItemsARecoger Dato;

        [System.Serializable]
        public struct ItemsARecoger
        {
            public string nombre;
            public int cantidad;
            public int itemId;
        }

        [Header("Recompensas")]
        public int Pregunta;
        public int Puntos;
    }

    public mision[] misions;
}
