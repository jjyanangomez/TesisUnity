using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuelo : MonoBehaviour
{
    // Start is called before the first frame update
    public int cantidad;
    public int ID;
    public Inventario Inv;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inv.AgrregarItem(ID,cantidad);
        }
    }
}
