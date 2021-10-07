using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Unity.AI.Navigation;

public class GenerateLevel : MonoBehaviour
{
    public GameObject BlockPrefab;
    public GameObject npcPrefab;
    public NavMeshSurface surface;
    public int BlockCount = 100;
    public int npcCount = 10;

    private string message = null;
    private double start;
    private double end;

    private float frame;
    private bool test;
    
    private int lastRecalculation = -1;
    void generateLevel() {
        var floor = GameObject.Find("Floor").transform;
        for(int i = 0; i < BlockCount; i++) {
            var x = UnityEngine.Random.Range( floor.position.x - floor.lossyScale.x/2, floor.position.x + floor.lossyScale.x/2 );
            var z = UnityEngine.Random.Range( floor.position.z - floor.lossyScale.z/2, floor.position.z + floor.lossyScale.z/2 );
            var scale = UnityEngine.Random.Range( 2, 7 );
            var degrees = UnityEngine.Random.Range(0,360);            
            GameObject newBlock = Instantiate(BlockPrefab, new Vector3(x,0,z), Quaternion.AngleAxis(degrees, floor.up));
            newBlock.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    void SpawnNPC()
    {
        var floor = GameObject.Find("Floor").transform;
        for (int i = 0; i < npcCount; i++)
        {
            var x = UnityEngine.Random.Range( floor.position.x - floor.lossyScale.x/2, floor.position.x + floor.lossyScale.x/2 );
            var z = UnityEngine.Random.Range( floor.position.z - floor.lossyScale.z/2, floor.position.z + floor.lossyScale.z/2 );
            GameObject newNPC = Instantiate(npcPrefab, new Vector3(0,1.5f,0), Quaternion.identity);
            //GameObject newNPC = Instantiate(npcPrefab, new Vector3(x,1.5f,z), Quaternion.identity);
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        test = true;
        start = Time.realtimeSinceStartupAsDouble;
        generateLevel();
        surface.BuildNavMesh();
        end = Time.realtimeSinceStartupAsDouble;
        
        SpawnNPC();
    }

    private void Update()
    {
        FrameCheck();
    }

    private void FrameCheck()
    {
        frame = Time.deltaTime;
        
        if (frame >= 0.017)
        {
            frame = Time.deltaTime;
            Debug.Log("OVER");
        }
    }

    /*void FrameCheck()
    {
        while (test)
        {
            frame = Time.deltaTime;
            
            if (frame >= 0.017)
            {
                frame = Time.deltaTime;
                Debug.Log("we got here");
                test = false;
            }
        }
    }*/
    
    void OnGUI() {
        /*if( message != null ) {
            GUI.Label(new Rect(30,30, 300, 30), message, "box");
        }*/
        
        GUI.Label(new Rect(30,30, 300, 30), (end - start).ToString(), "box");
        GUI.Label(new Rect(30,60, 300, 30), frame.ToString(), "box");
    }
    
}
