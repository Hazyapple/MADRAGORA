using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] AudioSource hitbutton; 
    public void ControlsMenuScript()
    {
        hitbutton.Play();
        SceneManager.LoadScene(1);
    }
}
