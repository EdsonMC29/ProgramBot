using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    private int point;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if(point == -1){
            textMesh.text = "GAME OVER";
        }
        else{
            textMesh.text = point.ToString("0");
            
        }
        if(point == 3)
            SceneManager.LoadScene("Level_3");
        
    }

    public void AddPoints()
    {
        point += 1;
    }
    public void gameOver()
    {
        
        point = -1;
    }
}
