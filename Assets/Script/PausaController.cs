using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaController : MonoBehaviour
{
    public GameObject pausa;
    public bool estoy;

    private void OnEnable()
    {
        InputManager.OnEscape += Escape;
    }

    private void OnDisable()
    {
        InputManager.OnEscape -= Escape;
    }

    private void Start()
    {
        pausa.SetActive(false);
    }

    private void Escape(bool es)
    {
        if (es == true && estoy == false)
        {
            Debug.Log("Aparece");
            pausa.SetActive(true);
            estoy = true;
        }

        else if(estoy == true)
        {
            Debug.Log("Desaparece");
            pausa.SetActive(false);
            estoy = false;
        }



    }
}
