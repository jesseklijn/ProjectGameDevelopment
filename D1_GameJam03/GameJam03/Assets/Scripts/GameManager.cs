using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {

    public enum Phases
    {
        none,
        pause,
        timeout,
        fighting

    }
    public Phases phase = Phases.timeout;
    public int lives, money, characterPoints, currentTurn;
    public GameObject Objective;
    public bool canBuy = true, canUpgrade = true;
    public GameObject selectedTower;
    public List<GameObject> Towers = new List<GameObject>();
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> EnemiesToSpawn = new List<GameObject>();
    public Vector3[] spawnPoints;
    private GameObject[] TowersArray;
    private GameObject[] EnemiesArray;
    public float timer, interval = 0.5F, phaseInterval = 20, spawnInterval = 1F;
    public bool isPlaying = false;
    public int selectedElement;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        EnemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        Enemies = new List<GameObject>(EnemiesArray);
        TowersArray = GameObject.FindGameObjectsWithTag("Enemy");
        Towers = new List<GameObject>(EnemiesArray);
        if(lives == 0)
        {
            Application.LoadLevel(0);
        }

    }

}
