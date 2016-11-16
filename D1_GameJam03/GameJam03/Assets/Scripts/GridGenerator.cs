using UnityEngine;
using System.Collections;

public class GridGenerator : MonoBehaviour {

    public int width, length;
    public GameObject tile;
    public GameObject tileParent;
	// Use this for initialization
	void OnStart () {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                Instantiate(tile, new Vector3(2*x, 0.5F , 2*z), Quaternion.identity, tileParent.transform);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
