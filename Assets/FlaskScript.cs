using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlaskScript : MonoBehaviour
{


    public Slider slider;

    public int maxFill = 100;
    public int currentFill;

    private void Start()
    {
        SetFlaskFill(0);
    }

    public void SetMaxFill(int fill)
    {
        slider.maxValue = fill;
        slider.value = fill;
    }

    public void SetFlaskFill(int fill)
    {
        currentFill = fill;
        slider.value = fill;
    }

    public void IncreaseFill(int amount)
    {
        this.SetFlaskFill(currentFill + amount);
    }
}
