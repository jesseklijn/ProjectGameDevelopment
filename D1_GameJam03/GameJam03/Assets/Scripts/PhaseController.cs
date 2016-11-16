using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PhaseController : MonoBehaviour
{
    public EnemyController enemyController;
    //public List<Phase> phases = new List<Phase>();

    public List<GameObject> ObjectsToSpawn(int currentTurn)
    {
        List<GameObject> objectsToReturn = new List<GameObject>();
        if (currentTurn == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                objectsToReturn.Add(enemyController.Enemies[0]);
            }
         

        }
        else if (currentTurn == 1)
        {
             for (int i = 0; i < 10; i++)
            {
                objectsToReturn.Add(enemyController.Enemies[0]);
            }
        }
        else if (currentTurn == 2)
        {
            for (int i = 0; i < 100; i++)
            {
                
                objectsToReturn.Add(enemyController.Enemies[0]);
            }
        }
        else if (currentTurn == 3)
        {
            for (int i = 0; i < 5; i++)
            {
                objectsToReturn.Add(enemyController.Enemies[0]);
            }
        }
        return objectsToReturn;
    }
}
//public class Phase
//{
//    public List<GameObject> ObjectsToReturn;
//    Phase(EnemyController enemyController)
//    {
//        ObjectsToReturn = new List<GameObject>();
//        ObjectsToReturn.Add(enemyController.Enemies[0]);
//    }
//}
