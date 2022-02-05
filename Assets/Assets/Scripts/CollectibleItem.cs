using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{   
    private int _hexbags;

    private int _flaskofglory;

    private int Mayapples = 0;

    private int FlaskOfGlory
    {
        get => this._flaskofglory;
        set
        {
            this._flaskofglory = value;
            updateFlaskOfGloryUI();
        }
    }

    private int Hexbags

    {
        get => this._hexbags;
        set
        {
            this._hexbags = value;
            updateUI();
        }
    }


    public FlaskScript flaskscript;


    [SerializeField] private Text MayapplesText;
    [SerializeField] private Text HexBagsText;
    [SerializeField] private Text FlaskOfGloryText;      

    private List<int> colletedIds = new List<int>();

    public GameObject flaskOfGlory;                     // this instantiate when slime collected 10/10, (flask max fill = 100) 



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mayapple"))
        {
            if (!colletedIds.Contains(collision.gameObject.GetInstanceID()))
            {
                Destroy(collision.gameObject);
                Mayapples++;
                colletedIds.Add(collision.gameObject.GetInstanceID());
                Debug.Log("Mayapples: " + Mayapples);
                MayapplesText.text = this.Mayapples.ToString();
            }
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            Destroy(collision.gameObject);

            flaskscript.IncreaseFill(10);                     //creates game object "FlaskOfGlory" when collected 10/10 slimes (flask max fill = 100)

           if(flaskscript.currentFill == 100)
            {
                Instantiate(flaskOfGlory, transform.position, Quaternion.identity);
                flaskscript.SetFlaskFill(0);
            }
        }

        if (collision.gameObject.CompareTag("HexBagLoot"))
        {
            if (!colletedIds.Contains(collision.gameObject.GetInstanceID()))
            {
                Destroy(collision.gameObject);
                Hexbags++;
                colletedIds.Add(collision.gameObject.GetInstanceID());
                Debug.Log("HexBagCollected: " + Hexbags);
            }

        }

        if(collision.gameObject.CompareTag("FlaskOfGlory"))     // destroy flask_loot and create flask_to_throw in inventory (use hex bag logic)
        {
            Destroy(collision.gameObject);
            FlaskOfGlory++;
            colletedIds.Add(collision.gameObject.GetInstanceID());
            Debug.Log("FlasksCollected: " + Hexbags);
        }
    }

    public bool hasHaxBags()
    {
        return this.Hexbags > 0;
    }

    private void updateUI()
    {
        HexBagsText.text = this.Hexbags.ToString();
    }
    public void useHexBag()
    {
        this.Hexbags--;
    }

    public bool hasFlasks()
    {
        return this.FlaskOfGlory > 0;
    }

    private void updateFlaskOfGloryUI()        //
    {
        FlaskOfGloryText.text = this.FlaskOfGlory.ToString();
    }

    public void useFlaskOfGlory ()
    {
        this.FlaskOfGlory--;
    }


}


