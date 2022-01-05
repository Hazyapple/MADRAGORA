using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    private int _hexbags;

    private int Mayapples = 0;
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

    private List<int> colletedIds = new List<int>();

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
                MayapplesText.text = "Mayapples: " + Mayapples;
            }
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            Destroy(collision.gameObject);

            flaskscript.IncreaseFill(10);
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
    }

    public bool hasHaxBags()
    {
        return this.Hexbags > 0;
    }

    private void updateUI()
    {
        HexBagsText.text = "Hexbags: " + this.Hexbags;
    }
    public void useHexBag()
    {
        this.Hexbags--;
    }
}

