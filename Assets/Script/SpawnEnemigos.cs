using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public List<GameObject> lista;
    public GameObject objeto;
   // public int numero;
    public Transform ubicacion;
    public int distancia = 5;
    public GameObject player;


    private void Start()
    {

       
    }

    private void Update()
    {
        if(player.transform.position.x > distancia )
        {
            objeto = lista[Random.Range(0, lista.Count)];
            distancia += 10;
            Instantiate(objeto, ubicacion.position + objeto.transform.position, ubicacion.rotation);
        }
        
    }
}
