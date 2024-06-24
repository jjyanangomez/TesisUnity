using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTrackerPanel : MonoBehaviour
{
    public QuestSystem dataB;
    public Jugador jug;

    public Text questDescriptionText;
    public Text questRecompensaText;
    public Button questNameButton;
    public Transform buttonContainer1;
    public Transform buttonContainer2;

    public bool showQuestFinished = false;
    private List<Button> poolButton = new List<Button>();


    public void ActualizarBotones()
    {
        List<Quest> questsT;
        if (!showQuestFinished)
        {
            questsT = jug.questTracker.activeQuests;
        }
        else
        {
            questsT = jug.questTracker.completeQuests;
        }

        if (poolButton.Count >= questsT.Count)
        {
            for (int i = 0; i < poolButton.Count; i++)
            {
                if (i < questsT.Count)
                {
                    int a = dataB.misions[questsT[i].id].id;
                    poolButton[i].GetComponentInChildren<Text>().text = dataB.misions[questsT[i].id].nombre;
                    poolButton[i].onClick.RemoveAllListeners();
                    poolButton[i].onClick.RemoveListener(() => ActualizarDescripcionesConInfo(a));
                    poolButton[i].GetComponentInChildren<Text>().color = Color.white;
                    Transform x;
                    x = showQuestFinished == false ? x = buttonContainer1 : x = buttonContainer2;
                    poolButton[i].transform.SetParent(x);
                    poolButton[i].gameObject.SetActive(true);
                }
                else
                {
                    poolButton[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = poolButton.Count; i < questsT.Count; i++)
            {
                Transform x;
                x = showQuestFinished == false ? x = buttonContainer1 : x = buttonContainer2;
                var nuevoBoton = Instantiate(questNameButton, x);
                int a = dataB.misions[questsT[i].id].id;
                nuevoBoton.GetComponentInChildren<Text>().text = dataB.misions[questsT[i].id].nombre;
                nuevoBoton.onClick.RemoveAllListeners();
                nuevoBoton.onClick.RemoveListener(() => { ActualizarDescripcionesConInfo(a); });
                poolButton.Add(nuevoBoton);
            }
            ActualizarBotones();
        }
    }
    
    public void ActualizarDescripcionesConInfo(int id)
    {
        if (id == -1)
        {
            questRecompensaText.text = string.Empty;
            questDescriptionText.text = string.Empty;
            return;
        }

        questDescriptionText.text = dataB.misions[id].descripcion;

        if (!jug.questTracker.completeQuests.Exists(x => x.id == id))
        {
            switch (dataB.misions[id].type)
            {
                case QuestSystem.Mision.QuestType.Recolectar:
                    if (jug.questTracker.DiscriminacionDeItems(dataB.misions[id].Datos[0].itemId)< dataB.misions[id].Datos[0].cantidad)
                    {
                        questRecompensaText.text = "Items recogidos:"+ " \n"+jug.questTracker.DiscriminacionDeItems(dataB.misions[id].Datos[0].itemId)+" / "+dataB.misions[id].Datos[0].cantidad;
                    }
                    else
                    {
                        questRecompensaText.text = "Has recogido todos los items! Ve con " + jug.questTracker.rewarders.Find(x => x.id_Mision == id).name + " para finalizar con la misión";
                    }
                    break;
                case QuestSystem.Mision.QuestType.Matar:
                    questRecompensaText.text = "No existen misiones para matar ";
                    break;
                case QuestSystem.Mision.QuestType.Entregar:
                    if (jug.questTracker.activeQuests.Find(x => x.id == id).destino.GetComponent<Destino_Script>().reached)
                    {
                        questRecompensaText.text = "Aun no has llegado!.";
                    }
                    else
                    {
                        questRecompensaText.text = "Completado! Ve con " + jug.questTracker.rewarders.Find(x => x.id_Mision == id).name + " para finalizar con la misión."; 
                    }
                    break;
                default:
                    questRecompensaText.text = "[Esperando Información]";
                    break;
            }
        }
    }
    public void SwapMisiones()
    {
        ActualizarDescripcionesConInfo(-1);
        showQuestFinished = !showQuestFinished;
    }
}
