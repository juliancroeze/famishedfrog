using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class hungerManager : MonoBehaviour
{
    private int hunger = 0;
    private GameObject hungerCube;
    // Start is called before the first frame update
    void Start()
    {
        hungerCube = GameObject.FindGameObjectWithTag("Hunger");   
    }

    // Update is called once per frame
    void Update()
    {
        Starve();
    }

    public void Starve()
    {
        hungerCube.transform.localScale += new Vector3(0.1f, 0, 0);
        hunger += 1;
        if (hunger == 4000)
        {
            passAway();
        }
    }

    public void Eat(int foodValue)
    {
        hungerCube.transform.localScale += new Vector3(-200f, 0, 0);
        hunger -= 1000;
    }
    public void passAway()
    {
        Debug.Log("You have passed away");
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
