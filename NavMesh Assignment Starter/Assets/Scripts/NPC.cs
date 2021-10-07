using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class NPC : MonoBehaviour
{
    public GameObject floor;
    public float duration;
    
    private float x, y, z;
    private float randX, randZ;
    private Vector3 pos;
    private NavMeshAgent npc;

    private void Start()
    {
        npc = GetComponent<NavMeshAgent>();
        x = floor.gameObject.transform.localScale.x / 2;
        y = floor.gameObject.transform.position.y;
        z = floor.gameObject.transform.localScale.z / 2;
        StartCoroutine("GenerateDes");
        //GenerateRandomDes();
    }
    
    /*private void GenerateRandomDes()
    {
        randX = Random.Range(-x, x);
        randZ = Random.Range(-z, z);
        
        pos = new Vector3(randX, y, randZ);

        this.npc.SetDestination(pos);
        //Debug.Log(gameObject.name + " destination: " + pos);
        this.Invoke("GenerateRandomDes", duration);
    }*/
 
    IEnumerator GenerateDes() 
    {
        while (true)
        {
            randX = Random.Range(-x, x);
            randZ = Random.Range(-z, z);
        
            pos = new Vector3(randX, y, randZ);

            npc.SetDestination(pos);
            yield return new WaitForSeconds(duration);
        }
    }
    
}
