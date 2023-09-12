using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public List<GameObject> lista;
    public GameObject objeto;
   // public int numero;
    public Transform ubicacion;
    public GameObject player;
    [SerializeField] private FMODUnity.StudioEventEmitter spawn;

    private void Start()
    {

       
    }

    private void Update()
    {
        if(player.transform.position.x >= 5 )
        {
            objeto = lista[Random.Range(0, lista.Count)];
            spawn.Play();
            Instantiate(objeto, ubicacion.position, ubicacion.rotation);
        }
        
    }
}
