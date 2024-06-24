using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPanel : MonoBehaviour
{
    public Transform[] UbicacionesPanel;
    public GameObject panelInformacion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UbicacionJohn()
    {
        panelInformacion.transform.position = UbicacionesPanel[0].position;
        panelInformacion.SetActive(true);
    }
    public void UbicacionLinda()
    {
        panelInformacion.transform.position = UbicacionesPanel[1].position;
        panelInformacion.SetActive(true);
    }
    public void UbicacionFred()
    {
        panelInformacion.transform.position = UbicacionesPanel[2].position;
        panelInformacion.SetActive(true);
    }
    public void UbicacionKelly()
    {
        panelInformacion.transform.position = UbicacionesPanel[3].position;
        panelInformacion.SetActive(true);
    }
}
