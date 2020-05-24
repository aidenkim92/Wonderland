using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class represents a bullet object which the boss shoots
 * @author Shahil
 * */
public class BossBullet : MonoBehaviour
{

    public float speed; //speed of bullet

    // Start is called before the first frame update
    void Start()
    {
        //transform.position += new Vector3(-speed* transform.localScale.x * Time.deltaTime, 0f, 0f);
        AudioManager.instance.PlaySFX(7);
    }

    // Update is called once per frame
    void Update()
    {


        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f); //Moves bullet according to time scale
    }

    //If bullet hits player, it damages player and destroys itself
    private void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("IT GETS HERE");
        if (other.isTrigger != true)
        {
            if (other.gameObject.tag == ("Player"))
            {

                other.GetComponent<Player>().Damage(1);
                Destroy(gameObject);
            }
        }
          
    }
}
