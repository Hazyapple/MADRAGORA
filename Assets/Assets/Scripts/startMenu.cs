using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    [SerializeField] AudioSource playsound;

    private void Start()
    {
        
 
    }

    public void StartGame()
    {
        playsound.Play();
        SceneManager.LoadScene(4);

        PlayerPrefs.SetInt("PlayerCurrentHealth", 100);

        

    }

}
