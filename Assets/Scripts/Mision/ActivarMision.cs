using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMision : MonoBehaviour
{
    [Header("Objetos de referencia")]
    public List<GameObject> Ubicacion = new List<GameObject>();

    [Header("Objetos que se generan")]
    public GameObject objeto_generar;

    public Manejador manejador;
    public int pistacho;
    // Start is called before the first frame update
    void Start()
    {

        if (pistacho == 1)
        {
            for (int i = 0; i < Manejador.numPreguntas[0]; i++)
            {
                float valorZ = Random.Range(Ubicacion[1].transform.position.z, Ubicacion[2].transform.position.z);
                float valorX = Random.Range(Ubicacion[3].transform.position.x, Ubicacion[2].transform.position.x);
                Vector3 v3 = new Vector3(valorX, Ubicacion[1].transform.position.y, valorZ);
                Instantiate(objeto_generar, v3, Quaternion.identity);

            }
        }
        else if (pistacho == 2)
        {
            for (int i = 0; i < Manejador.numPreguntas[1]; i++)
            {
                float valorZ = Random.Range(Ubicacion[0].transform.position.z, Ubicacion[2].transform.position.z);
                float valorX = Random.Range(Ubicacion[1].transform.position.x, Ubicacion[3].transform.position.x);
                Vector3 v3 = new Vector3(valorX, Ubicacion[1].transform.position.y, valorZ);
                Instantiate(objeto_generar, v3, Quaternion.identity);

            }
        }
        else if (pistacho == 3)
        {
            for (int i = 0; i < Manejador.numPreguntas[3]; i++)
            {
                float valorZ = Random.Range(Ubicacion[1].transform.position.z, Ubicacion[2].transform.position.z);
                float valorX = Random.Range(Ubicacion[3].transform.position.x, Ubicacion[2].transform.position.x);
                Vector3 v3 = new Vector3(valorX, Ubicacion[1].transform.position.y, valorZ);
                Instantiate(objeto_generar, v3, Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
