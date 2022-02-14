using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] AudioSource loot;
    [SerializeField] AudioSource flaskisfilled;
    [SerializeField] AudioSource gianthexobtained;

    private int _hexbags;

    private int _flaskofglory;

    private int _giantmayhexbag;

    private int _mayapples;

    private int _madeagiantmayhex;



    private int Mayapples  
     {
        get => this._mayapples;
        set
        {
            this._mayapples = value;
            updateMayapplesUI();
}
    }
  

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

    private int GiantMayHexBags

    {
        get => this._giantmayhexbag;
        set
        {
            this._giantmayhexbag = value;
            updatGiantMayHexbageUI();
        }
    }

    public FlaskScript flaskscript;

    public GiantMayUiScript giantmayscript;

   


    [SerializeField] private Text MayapplesText;     //
    [SerializeField] private Text HexBagsText;
    [SerializeField] private Text FlaskOfGloryText;
    [SerializeField] private Text GiantMayHexbagText;


    private List<int> colletedIds = new List<int>();

    public GameObject flaskOfGlory;                     // this instantiate when slime collected 10/10, (flask max fill = 100) 

    public GameObject mayhexbag;      //



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mayapple"))
        {
            if (!colletedIds.Contains(collision.gameObject.GetInstanceID()))
            {
                loot.Play();

                Destroy(collision.gameObject);
              
                Mayapples++;
                colletedIds.Add(collision.gameObject.GetInstanceID());   

                giantmayscript.IncreaseMayapplesFill(1);

                Debug.Log("Mayapples: " + Mayapples);

                //counts 10/10 mayapples than instantiate one Giant MayHexBag and set may apples back to 0/10


                if (has10Mayapples())
                {
                    gianthexobtained.Play();

                    Instantiate(mayhexbag, transform.position, Quaternion.identity);

                    giantmayscript.SetCurrentMayapples(0);

                    useMayapples();

                    loot.Play();





                }
                




            }
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            loot.Play();

            Destroy(collision.gameObject);

            flaskscript.IncreaseFill(10);                     //creates game object "FlaskOfGlory" when collected 10/10 slimes (flask max fill = 100)

            if (flaskscript.currentFill == 100)
            {
                flaskisfilled.Play();

                Instantiate(flaskOfGlory, transform.position, Quaternion.identity);
                flaskscript.SetFlaskFill(0);
            }
        }

        if (collision.gameObject.CompareTag("HexBagLoot"))
        {
            if (!colletedIds.Contains(collision.gameObject.GetInstanceID()))
            {
                loot.Play();

                Destroy(collision.gameObject);
                Hexbags++;
                colletedIds.Add(collision.gameObject.GetInstanceID());
                Debug.Log("HexBagCollected: " + Hexbags);
            }

        }

        if (collision.gameObject.CompareTag("FlaskOfGlory"))     // destroy flask_loot and create flask_to_throw in inventory (use hex bag logic)
        {
            flaskisfilled.Play();

            Destroy(collision.gameObject);
            FlaskOfGlory++;
            colletedIds.Add(collision.gameObject.GetInstanceID());
            Debug.Log("FlasksCollected: " + Hexbags);
        }

        if (collision.gameObject.CompareTag("MayHexBagLoot"))
        {

            if (!colletedIds.Contains(collision.gameObject.GetInstanceID()))
            {
                Destroy(collision.gameObject);
                GiantMayHexBags++;
                colletedIds.Add(collision.gameObject.GetInstanceID());
                Debug.Log("GiantMayHexBags: " + Hexbags);
            }

        }
    }

    //HexBags (brown)
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


    // Flasks 

    public bool hasFlasks()
    {
        return this.FlaskOfGlory > 0;
    }

    private void updateFlaskOfGloryUI()        
    {
        FlaskOfGloryText.text = this.FlaskOfGlory.ToString();
    }

    public void useFlaskOfGlory()
    {
        this.FlaskOfGlory--;
    }


    // GiantMayHexBags

    public bool hasGiantMayHexbag()
    {
        return this.GiantMayHexBags > 0;
    }

    private void updatGiantMayHexbageUI()
    {
        GiantMayHexbagText.text = this.GiantMayHexBags.ToString();
    }

    public void useGiantMayHexBag()
    {
        this.GiantMayHexBags--;
    }

    //Mayapples

    public bool has10Mayapples()
    {
        return this.Mayapples >= 10;   
    }
    private void updateMayapplesUI()
    {
        MayapplesText.text = this.Mayapples.ToString();
    }

    public void useMayapples()
    {
        this._mayapples = 0;


    }


}








