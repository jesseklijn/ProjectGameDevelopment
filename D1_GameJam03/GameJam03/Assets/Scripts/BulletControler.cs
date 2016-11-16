using UnityEngine;
using System.Collections;

public class BulletControler : MonoBehaviour {

    public float damage;
    public int lifeTime;

	// Update is called once per frame
	void FixedUpdate () {

        //Max lifeTime for bullet so missed bullets won't stay around.
        lifeTime--;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}

    //When bullet hits enemy do something and destroy bullet
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().health -= (int)damage;
            
        }
    }
}
