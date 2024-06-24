using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int experiencia;
    public int Oro;

    public GameObject inventario;
    //private Mouselook mouseLook;

    public QuestSystem dataBase;

    public QuestTracker questTracker;

    public QuestTrackerPanel questTrackerPanel;

    public QuestPanel questPanel;

    [HideInInspector]
    public List<GameObject> invLocal = new List<GameObject>();

    private void Start()
    {
        questTracker.GetComponent<QuestTracker>();
        questTrackerPanel.gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bibliotecaria"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<QuestGiver>().ContactoConJugador(this);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Destino"))
        {
            other.GetComponent<Destino_Script>().reached = true;
            questTracker.ActualizarQuest(other.GetComponent<Destino_Script>().id_Quest, Quest.QuestType.Entregar);
        }
        if (other.transform.CompareTag("Item"))
        {
            invLocal.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bibliotecaria"))
        {
            questPanel.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questTrackerPanel.ActualizarBotones();
            questTrackerPanel.ActualizarDescripcionesConInfo(-1);
            questTrackerPanel.gameObject.SetActive(!questTrackerPanel.gameObject.activeSelf);
        }
    }
    public void Recompensar(Quest quest)
    {
        questTrackerPanel.ActualizarBotones();

        experiencia += dataBase.misions[quest.id].xp;
        Oro += dataBase.misions[quest.id].gold;

        questPanel.accept_Button.gameObject.SetActive(false);
        questPanel.deny_Button.gameObject.SetActive(false);
        if (dataBase.misions[quest.id].hasSpecialR)
        {
            if (dataBase.misions[quest.id].specialR.Length > 1)
            {
                string s = "Bien hecho! completaste " + dataBase.misions[quest.id].nombre + ", como recompensa has obtenido Oro (" + dataBase.misions[quest.id].gold + ") y puntos "+ dataBase.misions[quest.id].xp + ").";
            }
        }
        else
        {
            string s = "Bien hecho! completaste " + dataBase.misions[quest.id].nombre + ", como recompensa has obtenido Oro (" + dataBase.misions[quest.id].gold + ") y puntos " + dataBase.misions[quest.id].xp + ").";
        }
        if (quest.retieneItem)
        {
            List<GameObject> its = new List<GameObject>();
            int cantidadEliminar = quest.itemsARecoger[0].cantidad;

            for (int i = 0; i < invLocal.Count; i++)
            {
                if (invLocal[i].GetComponent<ItemSuelo>().ID == quest.itemsARecoger[0].itemId && cantidadEliminar >0)
                {
                    its.Add(invLocal[i]);

                    inventario.GetComponent<Inventario>().EliminarItem(invLocal[i].GetComponent<ItemSuelo>().ID, cantidadEliminar, false);

                    cantidadEliminar--;
                }
            }
            invLocal.RemoveAll(itemB =>
            {
                return its.Find(itemA => itemA == itemB);
            });

            foreach (var item in its)
            {
                Destroy(item);
            }
            its.Clear();
        }

        if (dataBase.misions[quest.id].hasSpecialR)
        {

        }
    }
}
