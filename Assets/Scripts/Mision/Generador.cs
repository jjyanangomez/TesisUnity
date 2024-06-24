using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject Padre_Objeto;
    public BaseMisiones BDMisiones;
    [Header("Objetos de referencia")]
    public GameObject objeto_Referencia_Bibliotecaria;
    public GameObject objeto_Referencia_Reloj;
    public GameObject objeto_Referencia_Circuito_Ayuda;
    public GameObject objeto_Referencia_Moneda;
    public GameObject objeto_Referencia_Didacta;
    public GameObject objeto_Referencia_Circuito_Armamento;
    public GameObject objeto_Referencia_Nave;
    public GameObject objeto_Referencia_Nave_Constructor;

    public GameObject objeto_Referencia_Constructor;

    [Header("Objetos que se generan")]
    public GameObject objeto_generar_Bibliotecaria;
    public GameObject objeto_generar_Reloj;
    public GameObject objeto_generar_Circuito_Ayuda;
    public GameObject objeto_generar_Moneda;
    public GameObject obejto_generar_Didacta;
    public GameObject objeto_generar_Circuito_Armamento;
    public GameObject objeto_generar_Nave;
    public GameObject objeto_generar_Nave_Constructor;

    public GameObject objeto_generar_Constructor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generar(int id)
    {
        GameObject objeto = null;
        if (BDMisiones.misions[0].id == id)
        {
            if (id == 0)
            {
                Debug.Log("Acabo de generar la bibliotecaria");
                objeto = Instantiate(objeto_generar_Bibliotecaria, objeto_Referencia_Bibliotecaria.transform.position, Quaternion.identity);
                objeto.transform.parent = Padre_Objeto.transform;
            }

        }
        else if (BDMisiones.misions[1].id == id)
        {
            Debug.Log("HOla");
            if (id == 1)
            {
                Debug.Log("Acabo de generar");
                objeto = Instantiate(objeto_generar_Reloj, objeto_Referencia_Reloj.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Reloj.transform;
            }
        }
        else if (BDMisiones.misions[2].id == id)
        {
            if (id == 2)
            {
                objeto = Instantiate(objeto_generar_Circuito_Ayuda, objeto_Referencia_Circuito_Ayuda.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Circuito_Ayuda.transform;
            }
        }
        else if (BDMisiones.misions[3].id == id)
        {
            if (id == 3)
            {
                objeto = Instantiate(objeto_generar_Moneda, objeto_Referencia_Moneda.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Moneda.transform;
            }
        }
        else if (BDMisiones.misions[4].id == id)
        {
            if (id == 4)
            {
                objeto = Instantiate(obejto_generar_Didacta, objeto_Referencia_Didacta.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Didacta.transform;
            }
        }
        else if (BDMisiones.misions[5].id == id)
        {
            if (id == 5)
            {
                objeto = Instantiate(objeto_generar_Circuito_Armamento, objeto_Referencia_Circuito_Armamento.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Circuito_Armamento.transform;
            }
        }
        else if (BDMisiones.misions[6].id == id)
        {
            if (id == 6)
            {
                objeto = Instantiate(objeto_generar_Nave, objeto_Referencia_Nave.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Nave.transform;
            }
        }
        else if (BDMisiones.misions[7].id == id)
        {
            if (id == 7)
            {
                objeto = Instantiate(objeto_generar_Nave_Constructor, objeto_Referencia_Nave_Constructor.transform.position, Quaternion.identity);
                objeto.transform.parent = objeto_Referencia_Nave_Constructor.transform;
            }
        }

    }
}
