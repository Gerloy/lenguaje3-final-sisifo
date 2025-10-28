using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCreceiver : MonoBehaviour
{
    Vector3 pos;
    Vector3 pos_base;
    [SerializeField] OSC osc;

    // Start is called before the first frame update
    void Start()
    {
        osc.SetAllMessageHandler(OnReceive);
        pos_base = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnReceive(OscMessage mensaje){
        pos = transform.position;
        if (mensaje.address == "/pos"){
            Debug.Log(mensaje);
            //mensaje.GetFloat(0); //Valor X
            //mensaje.GetFloat(2); //Valor Z
            pos = new Vector3(
                pos_base.x - mensaje.GetFloat(0),
                transform.position.y,
                pos_base.z - mensaje.GetFloat(2));
            Debug.Log(mensaje.GetFloat(2));
            Debug.Log(transform.position.z);
            transform.position = pos;
        }
    }
}
