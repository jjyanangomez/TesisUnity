using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quests",menuName ="QuestSystem",order = 1)]
public class QuestSystem : ScriptableObject
{
    [System.Serializable]
    public struct Mision
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
        public bool diferentesItems;
        public bool SeQuedaConItems;
        public List<ItemsARecoger> Datos;

        [System.Serializable]
        public struct ItemsARecoger
        {
            public string nombre;
            public int cantidad;
            public int itemId;
        }

        /*[Header("Misiones de Matar")]
        public int cantidad;
        public int enemyId;*/

        [Header("Recompensas")]
        public int gold;
        public int xp;
        public bool hasSpecialR;
        public SpecialRewardss[] specialR;

        [System.Serializable]
        public struct SpecialRewardss
        {
            public string nombre;
            public GameObject reward;
        }
    }
    public Mision[] misions;
    //public float precisionDestino = 1.5f;
}
