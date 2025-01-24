using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalacioAmlo : MonoBehaviour
{
    Rigidbody2D BalaErb;
    public GameObject balaEnemiga;
    public Transform spawnBala;

    void Start()
    {
        StartCoroutine(Spawner());
        BalaErb = GetComponent<Rigidbody2D>();
       
        
    }
    IEnumerator Spawner()
    {
        while (true)
        { 
         yield return new WaitForSeconds(2);
         Instantiate(balaEnemiga,spawnBala.position,Quaternion.identity);
        }
    }
    void Update()
    {

    }
 
}
