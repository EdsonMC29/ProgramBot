using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlDeBotones : MonoBehaviour
{
    public Button botonPlay;
    public Button botonInfo;
    public Button botonQuit;

    void Start()
    {
        // Asigna funciones a los botones
    }

    public void OnClickPlay()
    {
        // Cargar la escena de juego
        SceneManager.LoadScene("Level_1");
    }
    public void OnClickBack()
    {
        // Cargar la escena de juego
        SceneManager.LoadScene("Menu");
    }

    public void OnClickInfo()
    {
        // Muestra información (puedes cambiar esto según tus necesidades)
        SceneManager.LoadScene("Info");
    }

    public void OnClickQuit()
    {
        // Salir de la aplicación (solo funcionará en una compilación)
        Application.Quit();
    }
}
