using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int score;

    public TMP_Text textScore;

    public GameObject panelGameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addScore(int point){
        score+=point;
        textScore.text="Score: "+score;
    }

    public void gameOver(){
        panelGameOver.SetActive(true);
    }

    public void restartGame(string levelName){
        SceneManager.LoadScene(levelName);
    }

}
