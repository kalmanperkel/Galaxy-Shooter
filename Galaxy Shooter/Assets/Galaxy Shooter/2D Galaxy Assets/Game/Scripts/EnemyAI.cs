using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    //vartiable for the speed
    private float _Speed = 4.0f;
	
	// Update is called once per frame
	void Update ()
    {
        //move down
        transform.Translate(Vector3.down * _Speed * Time.deltaTime);
        //when off the screen on the bottom
        //respawn back on top with a new x position between the bounds of the screen

        if (transform.position.y <= -7)
        {
            float randomX = (Random.Range(-7, 7));
            transform.position = new Vector3(randomX ,7, 0);
        }    
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {

            if (other.transform.parent.gameObject)
            {
               
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            //damage the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
        
    }
}
