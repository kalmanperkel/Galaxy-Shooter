using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerUpID;//0 = triple shot, 1 = speed boost, 2 = shields
    
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Player")
        {

            //access the player
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                if (powerUpID == 0)
                {
                    //enable triple shot
                    player.TripleShotPowerUpOn();
                }
                else if (powerUpID == 1)
                {
                    //enable speed boost
                    player.SpeedBoostPowerOn();
                }
                else if (powerUpID == 2)
                {
                    //enable shields
                }
                
            }

            //destroy ourself
            Destroy(this.gameObject);
        }
    }
}
