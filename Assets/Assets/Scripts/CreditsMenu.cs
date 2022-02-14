using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] AudioSource hitbutton;

    public void CreditsMenuMethod()
    {
        hitbutton.Play();
        SceneManager.LoadScene(2);
    }

}
