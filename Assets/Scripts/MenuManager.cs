using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  public  string SceneName;

    public Text scoreGT;

    void Start()
    {
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreGT.text = playerScore.ToString();
    }
    public void LoadSceneSelect()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OKButton()
    {
        SceneManager.LoadScene(SceneName);
    }  
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneName);
    }


}