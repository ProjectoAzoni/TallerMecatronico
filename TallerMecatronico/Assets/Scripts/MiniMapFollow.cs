using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    // asign the position of the  player
    [SerializeField] Transform player;

    private void LateUpdate()
    {
        //if there is a player
        if (player)
        {
            //get the current position of the player and save it into a new position
            Vector3 newPosi = player.position;
            //set the player Y position to my Y position 
            newPosi.y = transform.position.y;
            //set my position to the new position
            transform.position = newPosi;
            //rotate to the front y position of the player
            transform.rotation = Quaternion.Euler(90f, player.rotation.eulerAngles.y, 0f);
        }
    }
}
