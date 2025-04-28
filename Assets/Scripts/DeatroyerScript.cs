using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeatroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);

        Transform current = other.transform;

        while (current != null)
        {
           
            if (current.childCount > 0)
            {
                Transform childToDestroy = current.GetChild(0); 
                //Debug.Log("Destroying child: " + childToDestroy.name);
                Destroy(childToDestroy.gameObject);
                break; 
            }
            else
            {
                
                Transform parent = current.parent;
                //Debug.Log("Destroying empty: " + current.name);
                Destroy(current.gameObject);
                current = parent;
            }
        }
    }
}
