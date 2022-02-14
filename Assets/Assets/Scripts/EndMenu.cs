using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] AudioSource byesound;
    public void Quit()
    {
        byesound.Play();
        Application.Quit();
    }
}
