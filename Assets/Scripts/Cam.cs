using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private float tiempo = 3f;
    public Transform view;
    public float transitions;
    Transform currentView;

    void Start()
    {

        currentView = transform;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempo<=0)
        {
            currentView = view;
        }
        
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitions);
    }
}
