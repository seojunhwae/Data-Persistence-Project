using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Awake()
    {
       ScoreText.text = "Best Score : " + DataManager.Instance.bestUsername + " : " + DataManager.Instance.score;
    }
            
    public void OnInputChange(string value)
    {
        DataManager.Instance.username = value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif

        DataManager.Instance.SaveData();
    }
}
