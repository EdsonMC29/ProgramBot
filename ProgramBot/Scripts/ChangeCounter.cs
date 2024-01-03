using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCounter : MonoBehaviour
{
    public List<GameObject> proyectiles = new List<GameObject>();
    public GameObject trajectoryGameManager;
    private TrajectoryGameManager gameManagerScript;

    void Start()
    {
        gameManagerScript = trajectoryGameManager.GetComponent<TrajectoryGameManager>();
    }

    public void UpdateProjectileDisplay()
    {
        for (int i = 0; i < proyectiles.Count; i++)
        {
            proyectiles[i].SetActive(i < gameManagerScript.remainingProjectiles);
        }
    }
}
