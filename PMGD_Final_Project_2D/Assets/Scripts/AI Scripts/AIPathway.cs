using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Makes all instances of a script execute in Edit Mode.
[ExecuteInEditMode]
public class AIPathway : MonoBehaviour
{
    // List is similar to array but it has no exact size meaning you can add some GameObject as many as you like
    public List<GameObject> route;
    public bool drawLine = true;

    void Awake()
    {
        // If route equal to 0
        if (route == null)
        {
            // Add a new list
            route = new List<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying)
        {
            // If route equal to 0
            if (route == null)
            {
                // Add a new list
                route = new List<GameObject>();
            }
            route.Clear();
            foreach (Transform node in transform)
            {
                route.Add(node.gameObject);
            }
        }
        if (route != null && route.Count > 1)
        {
            if (drawLine)
            {
                DrawLine();
            }
            
        }
    }
    
    private void DrawLine()
    {
        int index = 0;
        Vector3 lastPos = route[index].transform.position;
        for (int i = 0; i < route.Count; i++)
        {
            Debug.DrawLine(lastPos, route[index].transform.position);
            lastPos = route[index].transform.position;

            if (index == route.Count - 1)
            {
                Debug.DrawLine(lastPos, route[0].transform.position);
            }
            index++;
        }
    }    
}
