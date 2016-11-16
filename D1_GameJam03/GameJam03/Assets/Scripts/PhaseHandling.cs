using UnityEngine;
using System.Collections;

public class PhaseHandling : MonoBehaviour
{

    //kopen
    //vechten
    //pauze
    public PhaseController phaseController;
    public TextMesh text;
    public GameObject enemiesListObject;
    private GameManager gameManager;
    public ShopGUI shopGUI;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPlaying == true)
        {
            if (gameManager.phase == GameManager.Phases.timeout)
            {
                if (gameManager.timer >= 0)
                {
                    gameManager.timer -= Time.deltaTime;
                    text.text = Mathf.RoundToInt(gameManager.timer).ToString();
                    //TODO: Buy turrets handler


                }
                else if (gameManager.timer <= 1)
                {
                    //Shopmode activated
                    shopGUI.noWaveActive = false;
                    text.text = "";
                    gameManager.timer = gameManager.phaseInterval;
                    gameManager.phase = GameManager.Phases.fighting;

                    
                    //Fighting phase starts, timeout ends

                    
                }
            }
            else if (gameManager.phase == GameManager.Phases.fighting)
            {
                if (gameManager.EnemiesToSpawn.Count > 0)
                {
                    if (gameManager.interval <= 0)
                    {
                        //keep spawning until list is empty
                        gameManager.interval = gameManager.spawnInterval;
                        Instantiate(gameManager.EnemiesToSpawn[0], gameManager.spawnPoints[0], Quaternion.identity, enemiesListObject.transform);
                        gameManager.EnemiesToSpawn.Remove(gameManager.EnemiesToSpawn[0]);


                    }
                    else if (gameManager.interval >= 0)
                    {
                        gameManager.interval -= Time.deltaTime;
                    }

                }
                else if (gameManager.Enemies.Count == 0)
                {
                    gameManager.currentTurn++;
                    gameManager.phase = GameManager.Phases.timeout;
                    shopGUI.noWaveActive = true;
                    //enemies added to list
                    gameManager.EnemiesToSpawn = phaseController.ObjectsToSpawn(gameManager.currentTurn);

                }
            }

        }

    }
}
