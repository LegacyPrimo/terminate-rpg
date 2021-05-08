using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActions : MonoBehaviour
{
    public EnemyScript[] enemyUnit;
    public ObjectBreak[] breakableObjects;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) 
        {
            for (int i = 0; i < enemyUnit.Length; i++) 
            {
                ChangeActivation(enemyUnit[i], true);
            }
            for (int i = 0; i < breakableObjects.Length; i++)
            {
                ChangeActivation(breakableObjects[i], true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            for (int i = 0; i < enemyUnit.Length; i++)
            {
                ChangeActivation(enemyUnit[i], false);
            }
            for (int i = 0; i < breakableObjects.Length; i++)
            {
                ChangeActivation(breakableObjects[i], false);
            }
        }
    }

    void ChangeActivation(Component component, bool activationCheck) 
    {
        component.gameObject.SetActive(activationCheck);
    }
}
