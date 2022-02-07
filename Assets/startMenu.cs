using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    private void Start()
    {
        
 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(4);
    }

}
