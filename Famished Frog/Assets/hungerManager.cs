using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hungerManager : MonoBehaviour
{
    public int hunger = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Starve();
    }

    public void Eat()
    {
        transform.localScale -= new Vector3(-20f, 0, 0);
        hunger -= 10;
    }
    public void Starve()
    {
            transform.localScale += new Vector3(0.5f, 0, 0);
            hunger += 1;
    }
}
