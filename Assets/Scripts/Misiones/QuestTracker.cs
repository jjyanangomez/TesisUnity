using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public QuestSystem Db;

    public List<Quest> activeQuests = new List<Quest>();

    public List<Quest> finishedQuests = new List<Quest>();

    public List<Quest> completeQuests = new List<Quest>();

    [HideInInspector] public List<QuestGiver> rewarders = new List<QuestGiver>();
    // Start is called before the first frame update
    
    public void ActualizarQuest(int quest_ID, Quest.QuestType type, int? cantItem = null )
    {
        var val = activeQuests.Find(x=> x.id == quest_ID);

        if (type == Quest.QuestType.Entregar)
        {
            if (val.destino.GetComponent<Destino_Script>().reached)
            {
                val.complete = true;
            }
            else
            {
                Debug.Log("Aun no has llegado al Objetivo");
            }
        }
        if (type == Quest.QuestType.Recolectar)
        {
            foreach (var item in val.itemsARecoger)
            {
                if (cantItem !=null)
                {
                    if (cantItem == item.cantidad)
                    {
                        val.complete = true;
                    }
                    else
                    {
                        Debug.Log("Aun no has recolectado todos los items. Te faltan: "+(item.cantidad - cantItem));
                    }
                }
                

            }
        }
    }
    public void VerificarItem(int item_ID)
    {
        Quest q = null;
        if (activeQuests.Count > 0)
        {
            if (activeQuests.Exists(x => x.itemsARecoger.Exists(a => a.itemId == item_ID)))
            {
                q = activeQuests.Find(x => x.itemsARecoger.Exists(a => a.itemId == item_ID));
            }
            else
            {
                q = null;
                return;
            }
            for (int i = 0; i < activeQuests.Count; i++)
            {
                if (q.itemsARecoger[0].itemId == item_ID && activeQuests[i].id == q.id)
                {
                    int cantidad = DiscriminacionDeItems(Db.misions[activeQuests[i].id].Datos[0].itemId);
                    ActualizarQuest(activeQuests[i].id, activeQuests[i].type, cantidad);
                    q = null;
                    break;
                }
            }
        }
    }

    public int DiscriminacionDeItems(int id)
    {
        int itemsMatched = 0;

        foreach (var item in GetComponent<Jugador>().invLocal)
        {
            if (item.GetComponent<ItemSuelo>().ID == id)
            {
                itemsMatched++;
            }
        }
        return itemsMatched;
    }
    
}
