using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public QuestSystem dataB;
    public int id_Mision;
    public QuestPanel questPanel;

    [Space]
    public bool isStarted = false;
    public Quest quest;
    public bool rewarded = false;
    public bool isRewardGiver;

    public QuestGiver questRewarder;
    public QuestGiver prevQuestGiver;

    private Jugador jugador;

    private void Start()
    {
        for (int i = 0; i < dataB.misions.Length; i++)
        {
            if (dataB.misions[i].id == this.id_Mision)
            {
                quest.name = dataB.misions[i].nombre;
                quest.id = dataB.misions[i].id;
                quest.retieneItem = dataB.misions[i].SeQuedaConItems;
                quest.type = (Quest.QuestType)dataB.misions[i].type;
                if (dataB.misions[i].Datos != null)
                {
                    if (dataB.misions[i].Datos.Count > 0)
                    {
                        quest.itemsARecoger.Add(dataB.misions[i].Datos[0]);
                        if (quest.itemsARecoger.Count > 1)
                        {
                            quest.itemsARecoger.RemoveAt(1);
                        }
                    }
                }
                if (quest.destino != null)
                {
                    quest.destino.GetComponent<Destino_Script>().id_Quest = quest.id;
                    quest.destino.SetActive(false);
                }
            }
        }
        if (isRewardGiver)
        {
            questRewarder = this;
        }
        else
        {
            questRewarder.dataB = this.dataB;
            questRewarder.id_Mision = this.id_Mision;
            questRewarder.isStarted = this.isStarted;
            questRewarder.rewarded = this.rewarded;
            questRewarder.quest = this.quest;
            questRewarder.prevQuestGiver = this;
            questRewarder.quest.destino = this.quest.destino;
            questRewarder.questPanel = this.questPanel;
            if (quest.destino != null)
            {
                quest.destino.GetComponent<Destino_Script>().id_Quest = quest.id;
            }
            if (questRewarder.questRewarder = questRewarder)
            {
                questRewarder.isRewardGiver = true;
            }
            else
            {
                questRewarder.isRewardGiver = false;
            }

        }
    }

    public void ContactoConJugador(Jugador jug)
    {
        jugador = jug;
        if (!rewarded)
        {
            if (!isStarted)
            {
                if (prevQuestGiver == null)
                {
                    questPanel.accept_Button.gameObject.SetActive(true);
                    questPanel.deny_Button.gameObject.SetActive(false);

                    questPanel.ActualizarPanel(dataB.misions[id_Mision].nombre, dataB.misions[id_Mision].descripcion);

                    questPanel.accept_Button.onClick.RemoveAllListeners();
                    questPanel.accept_Button.onClick.AddListener(AceptarQuest);
                    questPanel.accept_Button.onClick.AddListener(jug.questTrackerPanel.ActualizarBotones);
                    questPanel.deny_Button.onClick.RemoveAllListeners();
                    questPanel.deny_Button.onClick.AddListener(delegate() { questPanel.gameObject.SetActive(false); });
                }
                else
                {
                    questPanel.accept_Button.gameObject.SetActive(false);
                    questPanel.deny_Button.gameObject.SetActive(false);
                    questPanel.ActualizarPanel("","No tengo ninguna mision para ti amigo!.");
                }
            }
            else
            {
                
                questRewarder.isStarted = true;
                if (jug.questTracker.activeQuests.Exists(x=> x.id == id_Mision))
                {
                    if (jug.questTracker.activeQuests.Find(x => x.id == id_Mision).complete)
                    {
                        if (isRewardGiver)
                        {
                            jug.questTracker.rewarders.Remove(this);
                            jug.Recompensar(quest);
                            rewarded = true;

                            var questTerminada = jug.questTracker.activeQuests.Find(x => x.id == id_Mision);

                            jug.questTracker.completeQuests.Add(questTerminada);
                            jug.questTracker.activeQuests.Remove(questTerminada);

                            if (quest.destino != null)
                            {
                                
                                Destroy(quest.destino);

                                quest.destino = null;
                            }
                            if (prevQuestGiver != null)
                            {
                                prevQuestGiver.rewarded = true;
                            }
                        }
                        else
                        {
                            Debug.LogWarning("Todavia no completas, debes ir a " + questRewarder.name);
                            questPanel.accept_Button.gameObject.SetActive(false);
                            questPanel.deny_Button.gameObject.SetActive(false);
                            questPanel.ActualizarPanel(dataB.misions[id_Mision].nombre, "para finalizar debes ver a " + questRewarder.name);
                        }
                    }
                    else
                    {
                        questPanel.accept_Button.gameObject.SetActive(false);
                        questPanel.deny_Button.gameObject.SetActive(false);

                        if (dataB.misions[id_Mision].type == QuestSystem.Mision.QuestType.Recolectar)
                        {
                            jug.questTracker.ActualizarQuest(id_Mision, (Quest.QuestType)dataB.misions[id_Mision].type, jug.questTracker.DiscriminacionDeItems(dataB.misions[id_Mision].Datos[0].itemId));
                            questPanel.ActualizarPanel(dataB.misions[id_Mision].nombre, "Aun no has recolectado todos los items. Te faltan: "
                                + (  dataB.misions[id_Mision].Datos[0].cantidad - jug.questTracker.DiscriminacionDeItems(dataB.misions[id_Mision].Datos[0].itemId)));
                        }
                        else
                        {
                            jug.questTracker.ActualizarQuest(id_Mision, (Quest.QuestType)dataB.misions[id_Mision].type, jug.questTracker.DiscriminacionDeItems(dataB.misions[id_Mision].Datos[0].itemId));
                            questPanel.ActualizarPanel(dataB.misions[id_Mision].nombre, "Aun no has completado el objetivo.");
                        }
                    }
                }
            }
        }
    }

    public void AceptarQuest()
    {
        questPanel.gameObject.SetActive(false);
        Debug.LogWarning("Mision "+dataB.misions[id_Mision].nombre + " iniciada!. ");
        jugador.questTracker.activeQuests.Add(new Quest { id = id_Mision, itemsARecoger = quest.itemsARecoger, type = quest.type, destino = quest.destino });

        if (dataB.misions[id_Mision].type == QuestSystem.Mision.QuestType.Recolectar)
        {
            jugador.questTracker.ActualizarQuest(id_Mision, (Quest.QuestType)dataB.misions[id_Mision].type, jugador.questTracker.DiscriminacionDeItems(dataB.misions[id_Mision].Datos[0].itemId));

        }
        else
        {
            jugador.questTracker.ActualizarQuest(id_Mision, (Quest.QuestType)dataB.misions[id_Mision].type);
        }

        questRewarder.isStarted = true;
        this.isStarted = true;

        if (quest.destino != null)
        {
            quest.destino.SetActive(true);
        }

        if (jugador.questTracker.activeQuests.Exists(x => x.id == id_Mision))
        {
            if (jugador.questTracker.activeQuests.Find(x => x.id == id_Mision).complete)
            {
                ContactoConJugador(jugador);
            }
        }

        jugador.questTracker.rewarders.Add(questRewarder);
    }

}
