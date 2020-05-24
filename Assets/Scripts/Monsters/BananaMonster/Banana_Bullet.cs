using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana_Bullet : MonoBehaviour
{
    public float speed;
    public bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position += new Vector3(-speed* transform.localScale.x * Time.deltaTime, 0f, 0f);
        AudioManager.instance.PlaySFX(6);
    }

    // Update is called once per frame
    void Update()
    {


        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger != true)
        {
            if (other.gameObject.tag == ("Player"))
            {

                other.GetComponent<Player>().Damage(1);
                Destroy(gameObject);
                isDestroyed = true;
            }
        }

    }
}
