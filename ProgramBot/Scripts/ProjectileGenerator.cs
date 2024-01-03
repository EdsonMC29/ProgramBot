using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject trajectoryGameManager;
    private List<GameObject> instantiatedObjects = new List<GameObject>();

    public void CreateNewProjectileWithDelay()
    {
        Invoke("CreateNewProjectile", 2f);
    }

    public void CreateNewProjectile()
    {
        if(trajectoryGameManager.GetComponent<TrajectoryGameManager>().remainingProjectiles > 0){
            GameObject obj = Instantiate(spawnObject, transform.position, Quaternion.identity);
            obj.SetActive(true);
            instantiatedObjects.Add(obj);
            trajectoryGameManager.GetComponent<TrajectoryGameManager>().remainingProjectiles--;
        }
    }

    public void DeleteAllProjectiles()
    {
        foreach (GameObject obj in instantiatedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        instantiatedObjects.Clear();
    }
}
