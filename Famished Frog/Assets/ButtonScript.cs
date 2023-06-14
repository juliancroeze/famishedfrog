using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        onClick();
    }

    // Update is called once per frame
    void onClick()
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
        Thread.Sleep(10000);
        SceneManager.LoadScene(sceneName: "Scenes/SampleScene");

    }
}
