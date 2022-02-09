using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiantMayUiScript : MonoBehaviour
{
    [SerializeField] private Text mayapples;

    public int maxMayapples = 10;
    public int currentMayapples;

    private bool hasnoMayapples;

    private void Start()
    {
        SetCurrentMayapples(0);
    }


    public void SetCurrentMayapples(int amount)
    {
        currentMayapples = amount;

        if (currentMayapples == 0)
        {
            hasnoMayapples = true;

        } else
        {
            hasnoMayapples = false;
        }
       // MayapplesText.text = this.ToString();
        
       
    }

    public void IncreaseMayapplesFill(int amount)
    {
        this.SetCurrentMayapples(currentMayapples + amount);
    }




  
}
