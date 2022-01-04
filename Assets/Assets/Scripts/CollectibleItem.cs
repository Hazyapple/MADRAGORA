using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItem : MonoBehaviour
{
    private int Mayapples = 0;

    public FlaskScript flaskscript;


    [SerializeField] private Text MayapplesText;
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

    }
    

    }

