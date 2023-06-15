using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class pointManager : MonoBehaviour
{
    private int points;
    private Text UIText;

    public void addPoints(int amount)
    {
        UIText = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        int.TryParse(UIText.text, out points);
        points += amount;
        if (points >= 10)
        {
            finishLevel();
        }
    }
    public int getPoints() { 
        return points; }
    public void finishLevel()
    {
    }

    private void Start(int uIText)
    {
        UIText = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        int.TryParse(UIText.text, out points);
    }
}
