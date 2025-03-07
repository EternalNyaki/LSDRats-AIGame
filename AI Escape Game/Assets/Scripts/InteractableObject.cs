using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interactable Object component
//Component that lets an object output a message to the console which interacted with by the player
public class InteractableObject : MonoBehaviour
{
    //Reference to a player that could interact with this object
    protected PlayerController _player = null;

    // Update is called once per frame
    void Update()
    {
        if (_player != null && Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player == null)
        {
            //If the triggering collider is a player, get a reference to it
            _player = collision.gameObject.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Clear the player reference
        if (_player != null && _player.gameObject == collision.gameObject)
        {
            _player = null;
        }

        AfterExit();
    }

    protected virtual void AfterExit()
    {

    }

    //Interact Method
    //Writes a message to the console when a player interacts with this object
    //Can be overriden for alternative functionality
    public virtual void Interact()
    {

    }
}
