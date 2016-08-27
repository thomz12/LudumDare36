using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandscapeGen : MonoBehaviour {

    public GameObject Landscape;
    private int spawnCount = 0;

    public int detail;
    public int roughness;
    public const float size = 480;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("MainCamera").transform.position.x >= 190 + 480 * spawnCount)
        {
            GameObject go = (GameObject)Instantiate(Landscape);
            spawnCount++;
            go.transform.position = new Vector3(480 * spawnCount, 0, 0);
            go.transform.SetParent(this.gameObject.transform);

            Mesh m = new Mesh();

            int prevHeight = 10;

            float stepsize = size / detail;

            List<Vector3> verts = new List<Vector3>();
            List<int> indicies = new List<int>();

            for (int i = 0; i < detail; i++)
            {
                int newHeight = Random.Range(-10, 10);

                verts.Add(new Vector3(i * stepsize, prevHeight, 0));
                verts.Add(new Vector3(i * stepsize, -10, 0));
                verts.Add(new Vector3(i * stepsize + stepsize, newHeight, 0));
                verts.Add(new Vector3(i * stepsize + stepsize, -10, 0));

                prevHeight = newHeight;

                int offset = i * 4;

                indicies.Add(offset + 2);
                indicies.Add(offset + 1);
                indicies.Add(offset + 0);
                indicies.Add(offset + 2);
                indicies.Add(offset + 3);
                indicies.Add(offset + 1);
            }

            m.vertices = verts.ToArray();
            m.triangles = indicies.ToArray();

            go = (GameObject)Instantiate(new GameObject());
            go.name = "special";
            go.AddComponent<MeshRenderer>();
            go.AddComponent<MeshFilter>();
            go.GetComponent<MeshFilter>().mesh = m;
            go.transform.position = new Vector3(size * spawnCount, 0, 5);
        }
	}
}
