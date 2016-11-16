using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Pathfinding : MonoBehaviour
{

    public GameObject target;
    public GameObject currentTile;
    public GameObject[] tiles;
    public List<GameObject> openList = new List<GameObject>();
    public List<GameObject> closedList = new List<GameObject>();
    public bool targetIsFound = false;
    float towardDistance;
    float distance, curDistance = 0;
    Ray ray;
    RaycastHit hit;
    Tile tile;
    // Use this for initialization
    void Start()
    {

        tiles = GameObject.FindGameObjectsWithTag("tile");

    }

    // Update is called once per frame
    void Update()
    {
        //Stap 1: Bereken distance voor elke adjacent tile
        //Stap 2: 
        //Stap 3:
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked();
        }
        if (Input.GetMouseButtonDown(1))
        {
            MazeCreator();
        }



    }
    void MouseClicked()
    {
        #region Reset
        foreach (var item in tiles)
        {

            tile = item.GetComponent<Tile>();
            tile.F = 0;
            tile.parent = null;
            if(tile.GetComponent<Tile>().notreachable == false)
            {
                tile.GetComponent<Tile>().tileobject.GetComponent<Renderer>().material.color = Color.grey;
            }
          
        }
        openList.Clear();
        closedList.Clear();
        targetIsFound = false;
        #endregion
        #region starting point
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            currentTile = hit.transform.parent.parent.gameObject;
        }
        #endregion

        openList.Add(currentTile);

        #region target
        target = GameObject.Find("92");

        #endregion
        while (targetIsFound == false)
        {
            checkForAdjacentTiles();
        }
        target.gameObject.GetComponent<Tile>().tileobject.GetComponent<Renderer>().material.color = Color.yellow;



    }
    void checkForAdjacentTiles()
    {
        int i = 0;

        currentTile = openList[0];
        closedList.Add(currentTile);
        openList.Remove(openList[0]);

        foreach (GameObject tile in tiles)
        {

            distance = Vector3.Distance(currentTile.transform.position, tile.transform.position);




            if (distance < 0.9F & distance > 0 && tile.GetComponent<Tile>().notreachable == false)
            {
                i++;
                if (tile != target && targetIsFound == false)
                {
                    towardDistance = (Vector3.Distance(tile.transform.position, target.transform.position) * tile.GetComponent<Tile>().modifier);
                    tile.GetComponent<Tile>().F = distance + towardDistance;

                    if (openList.Contains(tile) == false)
                    {
                        if (closedList.Contains(tile) == false)
                        {
                            openList.Add(tile);
                            tile.GetComponent<Tile>().tileobject.GetComponent<Renderer>().material.color = new Color(0, 0.5F, 0.5F);
                            tile.GetComponent<Tile>().parent = currentTile;
                        }
                    }
                    else
                    {
                      if(currentTile.GetComponent<Tile>().G < (tile.GetComponent<Tile>().G + tile.GetComponent<Tile>().G))
                        {
                            tile.GetComponent<Tile>().parent = currentTile;
                        }
                      //A B, G de best  => G F => opnieuw sorten  
                    }
                }
                else
                {
                    closedList.Add(target);
                    targetIsFound = true;
                    showRoute();
                    break;
                }
                if (i >= 6) { break; }
            }


        }

        openList = openList.OrderBy(x => x.GetComponent<Tile>().F).ToList();
    }

    void showRoute()
    {
        foreach (var tile in closedList)
        {
            tile.GetComponent<Tile>().tileobject.GetComponent<Renderer>().material.color = new Color(1F, 0, 0.5F);
        }
    }
    public void MazeCreator()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.parent.parent.gameObject.GetComponent<Tile>().notreachable == true)
            {
                hit.transform.parent.parent.gameObject.GetComponent<Tile>().notreachable = false;
                hit.transform.parent.parent.gameObject.GetComponent<Tile>().tileobject.GetComponent<Renderer>().material.color = Color.grey;
            }
            else
            {
                hit.transform.parent.parent.gameObject.GetComponent<Tile>().notreachable = true;
                hit.transform.parent.parent.gameObject.GetComponent<Tile>().tileobject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            }


        }

    }
}
