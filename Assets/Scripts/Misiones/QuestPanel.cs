using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestPanel : MonoBehaviour
{
    //[HideInInspector]
    public GameObject questMainPanel;

    public TextMeshProUGUI questName;
    public Text questDescription;
    public Button accept_Button;
    public Button deny_Button;

    private void Awake()
    {
        questMainPanel = this.gameObject;
        questMainPanel.SetActive(false);
    }
    public void ActualizarPanel(string name,  string Description)
    {
        this.questName.text = name;
        this.questDescription.text = Description;
        questMainPanel.SetActive(true);
    }
}
