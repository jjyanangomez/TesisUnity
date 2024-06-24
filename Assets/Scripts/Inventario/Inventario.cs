using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Inventario : MonoBehaviour
{
    [System.Serializable]
    public struct ObjetosInventarioID
    {
        public int id;
        public int cantidad;

        public ObjetosInventarioID(int id, int cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }
    }

    [SerializeField]
    DataBase data;
    [Header ("Variables de Drag and Drop")]
    public GraphicRaycaster graphRay;
    private PointerEventData pointerData;
    private List<RaycastResult> raycastResults;
    public static Transform canvas;
    public GameObject objetoSeleccionado;
    public Transform ExParent;
    [Header("Prefs y items")]
    public static GameObject Descripcion;
    //public CartelEliminacion CE;
    public int OSC;
    public int OSID;

    public Transform Contenido;
    public Item item;
    public List<ObjetosInventarioID> inventariooo = new List<ObjetosInventarioID>();
    // Start is called before the first frame update
    void Start()
    {
        InventoryUpdate();
        pointerData = new PointerEventData(null);
        raycastResults = new List<RaycastResult>();

        Descripcion = GameObject.Find("Descripcion");

        //CE.gameObjetc.SetActive(false);

        canvas = transform.parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Arrastrar();
    }

    void Arrastrar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointerData.position = Input.mousePosition;
            graphRay.Raycast(pointerData, raycastResults);
            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>())
                {
                    objetoSeleccionado = raycastResults[0].gameObject;
                    ExParent = objetoSeleccionado.transform.parent.transform;
                    objetoSeleccionado.transform.SetParent(canvas);
                }
            }
        }
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.GetComponent<RectTransform>().localPosition = CanvasScreen(Input.mousePosition);
        }
        if (objetoSeleccionado != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                pointerData.position = Input.mousePosition;
                raycastResults.Clear();
                graphRay.Raycast(pointerData,raycastResults);
                if (raycastResults.Count>0)
                {
                    foreach (var resultado in raycastResults)
                    {
                        if (resultado.gameObject.CompareTag("Celda"))
                        {
                            if (resultado.gameObject.GetComponentInChildren<Item>() == null)
                            {
                                objetoSeleccionado.transform.SetParent(resultado.gameObject.transform);
                                objetoSeleccionado.transform.localPosition = Vector2.zero;
                                ExParent = objetoSeleccionado.transform.parent.transform;
                                //Para cuando la celda se encuentre libre
                            }
                            else
                            {
                                if (resultado.gameObject.GetComponentInChildren<Item>().ID == objetoSeleccionado.GetComponent<Item>().ID)
                                {
                                    //Para cuando dos objetos con el mismo ID se verifiquen y sumen
                                    resultado.gameObject.GetComponentInChildren<Item>().cantidad += objetoSeleccionado.GetComponent<Item>().cantidad;
                                    Destroy(objetoSeleccionado.gameObject);
                                }
                                else
                                {
                                    //Para cuando dos objetos de distinto ID se verifiquen y se restaure la posicion sin afectar al otro objeto
                                    //objetoSeleccionado.transform.SetParent(ExParent.transform);
                                    //objetoSeleccionado.transform..localPosition = Vector2.zero;
                                    objetoSeleccionado.transform.SetParent(resultado.gameObject.transform.parent);
                                    resultado.gameObject.transform.SetParent(ExParent);
                                    resultado.gameObject.transform.localPosition = Vector3.zero;
                                }
                            }
                        }
                        else
                        {
                            //Para cuando se sale y suelta el objeto fuera del inventario
                            objetoSeleccionado.transform.SetParent(ExParent.transform);
                            objetoSeleccionado.transform.localPosition = Vector3.zero;
                        }
                    }
                }
                objetoSeleccionado = null;
            }
        }
        raycastResults.Clear();
    }
    public Vector2 CanvasScreen(Vector2 screenPos)
    {
        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(screenPos);
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        return (new Vector2(viewportPoint.x*canvasSize.x, viewportPoint.y * canvasSize.y)-(canvasSize/2));
    }

    public void AgrregarItem(int id, int cantidad)
    {
        for (int i = 0; i < inventariooo.Count; i++)
        {
            if (inventariooo[i].id == id && data.baseDatos[id].acumulable)
            {
                inventariooo[i] = new ObjetosInventarioID(inventariooo[i].id, inventariooo[i].cantidad + cantidad);
                InventoryUpdate();
                return;
            }
        }
        if (!data.baseDatos[id].acumulable)
        {
            inventariooo.Add(new ObjetosInventarioID(id, 1));
        }
        else
        {
            inventariooo.Add(new ObjetosInventarioID(id, cantidad));
        }
        InventoryUpdate();
    }
    public void EliminarItem(int id, int cantidad, bool valor)
    {
        for (int i = 0; i < inventariooo.Count; i++)
        {
            if (inventariooo[i].id == id)
            {
                inventariooo[i] = new ObjetosInventarioID(inventariooo[i].id, inventariooo[i].cantidad - cantidad);
                if (inventariooo[i].cantidad <= 0)
                {
                    inventariooo.Remove(inventariooo[i]);
                    InventoryUpdate();
                    break;
                }
            }
            InventoryUpdate();
        }
    }

    List<Item> pool = new List<Item>();
    public void InventoryUpdate()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (i < inventariooo.Count)
            {
                ObjetosInventarioID o = inventariooo[i];
                pool[i].ID = o.id;
                pool[i].GetComponent<Image>().sprite = data.baseDatos[o.id].icono;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].cantidad = o.cantidad;
                pool[i].Boton.onClick.RemoveAllListeners();
                pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(data.baseDatos[o.id].Void, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
            else
            {
                pool[i].gameObject.SetActive(false);
                pool[i]._descripcion.SetActive(false);
                pool[i].gameObject.transform.parent.GetComponent<Image>().fillCenter = false;
            }
        }
        if (inventariooo.Count > pool.Count)
        {
            for (int i = 0; i < inventariooo.Count; i++)
            {
                Item it = Instantiate(item, Contenido.GetChild(i));
                pool.Add(it);

                if (Contenido.GetChild(0).childCount <=2)
                {
                    for (int s = 0; s < Contenido.childCount; s++)
                    {
                        if (Contenido.GetChild(s).childCount == 0)
                        {
                            it.transform.SetParent(Contenido.GetChild(s));
                            break; 
                        }
                    }
                }
                it.transform.position = Vector3.zero;
                it.transform.localScale = Vector3.one;

                ObjetosInventarioID o = inventariooo[i];
                pool[i].ID = o.id;
                pool[i].GetComponent<RectTransform>().localPosition = Vector3.zero;
                pool[i].GetComponent<Image>().sprite = data.baseDatos[o.id].icono;
                pool[i].cantidad = o.cantidad;
                pool[i].Boton.onClick.RemoveAllListeners();
                pool[i].Boton.onClick.AddListener(() => gameObject.SendMessage(data.baseDatos[o.id].Void, SendMessageOptions.DontRequireReceiver));
                pool[i].gameObject.SetActive(true);
            }
        }
    }
}
