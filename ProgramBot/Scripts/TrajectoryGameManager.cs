using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrajectoryGameManager : MonoBehaviour
{
    public int totalProjectiles; // Número de proyectiles
    public int remainingProjectiles; // Número de proyectiles restantes
    public GameObject changeCounter;
    public GameObject projectileGenerator; // Referencia al generador de proyectiles
    public GameObject gameOverScreen, completedScreen; // Pantallas UI para el fin del juego y pasar al siguiente nivel
    private string stateGame;
    public List<GameObject> pressurePlates = new List<GameObject>(); // Lista de placas de presión en el juego

    // Método para reiniciar el juego
    public void Restart()
    {
        projectileGenerator.GetComponent<ProjectileGenerator>().DeleteAllProjectiles();
        foreach (GameObject plate in pressurePlates)
        {
            plate.GetComponent<PressurePlate>().TurnOff(); // Asumiendo que las placas tienen un script 'PressurePlate' con el método 'TurnOff'
        }
        remainingProjectiles = totalProjectiles;
        changeCounter.GetComponent<ChangeCounter>().UpdateProjectileDisplay();
        stateGame = "IN_PROGRESS";
        projectileGenerator.GetComponent<ProjectileGenerator>().CreateNewProjectile();
    }

    public void NextLevel()
    {

        SceneManager.LoadScene("Level_2");

    }

    // Método para obtener el número de aciertos
    int GetHitCount()
    {
        int counter = 0;
        foreach (GameObject plate in pressurePlates)
        {
            if(plate.GetComponent<PressurePlate>().IsOn()) // Asumiendo que las placas tienen un script 'PressurePlate' con el método 'IsOn'
            {
                counter++;
            }
        }
        return counter;
    }

    void Start()
    {
        stateGame = "IN_PROGRESS";
        remainingProjectiles = totalProjectiles;
        projectileGenerator.GetComponent<ProjectileGenerator>().CreateNewProjectile();
    }

    void VerifyStateGame()
    {
        if(GetHitCount() == pressurePlates.Count)
            stateGame = "COMPLETED";
        else if(GetHitCount() < pressurePlates.Count && remainingProjectiles == 0)
            stateGame = "GAME_OVER";
        else
            stateGame = "IN_PROGRESS";
    }

    public void VerifyStateGameWithDelay()
    {
        Invoke("VerifyStateGame", 4f);
    }

    void Update()
    {
        switch(stateGame)
        {
            case "GAME_OVER":
                gameOverScreen.SetActive(true);
                completedScreen.SetActive(false);
                break;
            case "COMPLETED":
                gameOverScreen.SetActive(false);
                completedScreen.SetActive(true);
                break;
            case "IN_PROGRESS":
                gameOverScreen.SetActive(false);
                completedScreen.SetActive(false);
                break;
        }
    }
}
