using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canTripleShot = false;
    //variable to know if you collected the speed power up
    public bool isSpeedBoostActive = false;
    public int lives = 3;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;


    private float _canFire = 0.0f;


    [SerializeField]
    private float _speed = 5.0f;

	// Use this for initialization
	private void Start ()
    {
        
	}
	
	// Update is called once per frame
	private void Update ()
    {
        Movement();

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        if (Time.time > _canFire)
        {

            if (canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }

            _canFire = Time.time + _fireRate;


        }
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //if speed boost enabled
        //move 1.5x the normal speed
        //else
        //move normal speed

        if (isSpeedBoostActive == true)
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * 2.0f * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * 2.0f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }


        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0.3f);
        }
        else if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0.3f);
        }

        else if (transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0.3f);
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0.3f);
        }
    }

    public void Damage()
    {
        //substract 1 life from the player
        lives--;
        //if lives < 1
        //destroy this object

        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(tripleShotPowerDownRoutine());    }

    //method to enable to power up
    //coroutine method (ienumerator) to power down the speed boost
        public void SpeedBoostPowerOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(speedBoostPowerDownRoutine());
    }

    public IEnumerator speedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

    public IEnumerator tripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

}
