using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaController : MonoBehaviour
{
    public GameObject pausa;
    public bool estoy;
    [SerializeField] private FMODUnity.StudioGlobalParameterTrigger pausaSonidoReducido;
    [SerializeField] private FMODUnity.StudioGlobalParameterTrigger pausaSonidoNormal;

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
           // Debug.Log("Aparece");
            pausa.SetActive(true);
            pausaSonidoReducido.TriggerParameters();
            estoy = true;
        }

        else if(estoy == true)
        {
           // Debug.Log("Desaparece");
            pausa.SetActive(false);
            pausaSonidoNormal.TriggerParameters();
            estoy = false;
        }



    }
}
