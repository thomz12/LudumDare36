using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandscapeGen : MonoBehaviour {

    public GameObject Landscape;
    private int spawnCount = 0;

    public int detail;
    public int roughness;
    public int minHeight;
    public int maxHeight;

    public const float size = 100;

    private float oldHeight = -2.5f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("MainCamera").transform.position.x >= size * spawnCount)
        {
            GameObject go = (GameObject)Instantiate(Landscape);
            spawnCount++;
            go.transform.position = new Vector3(size * spawnCount, 0, 0);
            go.transform.SetParent(this.gameObject.transform);

            Mesh m = new Mesh();

            float stepsize = size / detail;

            List<Vector3> verts = new List<Vector3>();
            List<Vector2> vert2d = new List<Vector2>();
            List<int> indicies = new List<int>();

            for (int i = 0; i < detail; i++)
            {
                float delta = Random.Range(-roughness, roughness);

                float newHeight = oldHeight + delta;

                if (newHeight < minHeight)
                    newHeight = minHeight;
                if (newHeight > maxHeight)
                    minHeight = maxHeight;

                vert2d.Add(new Vector2(i * stepsize, oldHeight));
                vert2d.Add(new Vector2(i * stepsize, -10));
                vert2d.Add(new Vector2(i * stepsize + stepsize, newHeight));
                vert2d.Add(new Vector2(i * stepsize + stepsize, -10));

                verts.Add(vert2d[i]);
                verts.Add(vert2d[i + 1]);
                verts.Add(vert2d[i + 2]);
                verts.Add(vert2d[i + 3]);

                oldHeight = newHeight;

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
            go.transform.position = new Vector3(size * spawnCount - size / 2, 0, 5);
            go.AddComponent<PolygonCollider2D>();

            go.GetComponent<PolygonCollider2D>().points = vert2d.ToArray();
        }
	}
}
