using UnityEngine;
using System.Collections;

public class TowerPlot : MonoBehaviour
{
    public GameManager gameManager;
    public ShopGUI shopGUI;
    public Material[] materials;
    public GameObject[] tower;
    void OnMouseEnter()
    {
        if (shopGUI.towerCosts[gameManager.selectedElement] >= gameManager.money) { transform.GetComponent<Renderer>().material = materials[0]; }
        else { transform.GetComponent<Renderer>().material = materials[1]; }
       
       
    }

    void OnMouseExit()
    {
        transform.GetComponent<Renderer>().material = materials[2];

    }
    void OnMouseDown()
    {
        if (shopGUI.towerCosts[gameManager.selectedElement] >= gameManager.money)
        { //niks
        }
        else
        {
            //kopen
            gameManager.money -= shopGUI.towerCosts[gameManager.selectedElement];
            Instantiate(tower[gameManager.selectedElement], transform.position, Quaternion.identity, gameManager.transform);
            Destroy(gameObject);
        }

    }
}
