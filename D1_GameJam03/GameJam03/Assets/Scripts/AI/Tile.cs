using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    #region variables
    public GameObject tileobject;
    GameObject tilemap;
    TileGenerator tilegen;
    public TextMesh text;
    public bool isgoal = false, notreachable = false, steppedon = false;
    public float F, modifier = 1, G, H;
    public GameObject parent;

    Ray ray;
    RaycastHit hit;
    #endregion

    // Use this for initialization
    void Start()
    {
        //Generate tile data
        gameObject.name = "" + GameObject.FindGameObjectWithTag("tilegen").GetComponent<TileGenerator>().tilecount;
        GameObject.FindGameObjectWithTag("tilegen").GetComponent<TileGenerator>().tilecount++;
        tileobject.GetComponent<Renderer>().material.color = Color.gray;

        //Include this game object to tilemap
        tilemap = GameObject.FindGameObjectWithTag("tilemap");
        if (tilemap != null)
        {
            transform.parent = tilemap.transform;

        }
        else
        {
            Debug.Log("There is no tilemap! Please add a tilemap!");

        }

        //Change the name to the tile value
        text.text = gameObject.name;
    }
    void OnCollisionEnter(Collision collision)
    {
        steppedon = true;
    }
    void OnCollisionExit()
    {
        steppedon = false;
    }

}
