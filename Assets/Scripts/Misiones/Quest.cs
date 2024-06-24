using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public string name;
    public bool complete = false;
    public int id;
    public QuestType type;

    [Header("Para destino")]
    public GameObject destino;

    /*[Header("Para Enemigo")]
    public int idEmemigo;
    public int totalAmount;
    public int currentAmount;*/

    [Header("Para Item")]
    public bool retieneItem;
    public List<QuestSystem.Mision.ItemsARecoger> itemsARecoger = new List<QuestSystem.Mision.ItemsARecoger>();

    public enum QuestType
    {
        Recolectar,
        Matar,
        Entregar
    }
}
