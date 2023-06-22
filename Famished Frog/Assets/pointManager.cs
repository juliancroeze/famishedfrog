using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using System.Threading;
using UnityEngine.SceneManagement;


public class pointManager : MonoBehaviour
{
    private int points;
    private Text UIText;
    private GameObject complete;

    public void addPoints(int amount)
    {
        UIText = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        int.TryParse(UIText.text, out points);
        points += amount;
        if(points > 10) {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
    public int getPoints() { 
        return points; }
    public void finishLevel()
    {
    }

    private void Start()
    {
        UIText = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        int.TryParse(UIText.text, out points);
    }

    void Update() {

    }
}
