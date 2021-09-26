using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStack : MonoBehaviour
{
    public void ColliderActivation()
    {
        //List<Transform> children = new List<Transform>();
        
        foreach (Transform child in this.transform)
        {
            Collider2D col = child.GetComponent<Collider2D>();

            //children.Add(child);
            if (col != null)
            {
                //activate the last child object's collider
                col.enabled = false;
            }

        }

        //activate the last child object's collider
        if (transform.childCount > 0)
        {
            var topOfDeck = transform.GetChild(transform.childCount - 1);
            topOfDeck.GetComponent<Collider2D>().enabled = true;
            topOfDeck.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }


        
    }
}
