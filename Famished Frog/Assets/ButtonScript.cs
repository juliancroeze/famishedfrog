using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void sendToDeath()
    {
        Thread.Sleep(1000);
        SceneManager.LoadScene(sceneBuildIndex: 1);

    }
    public void sendToMenu()
    {
        Thread.Sleep(1000);
        SceneManager.LoadScene(sceneBuildIndex: 0);

    }
    public void sendToLevel1()
    {
        Thread.Sleep(1000);
        SceneManager.LoadScene(sceneBuildIndex: 2);

    }
    public void sendToLevel2()
    {
        Thread.Sleep(1000);
        SceneManager.LoadScene(sceneBuildIndex: 3);

    }
}
