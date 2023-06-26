using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedObject : MonoBehaviour
{
    // The new animal is what will be instantiated into the scene
    private GameObject newAnimal;

    // These are the actual prefabs that will be instantiated
    public GameObject Bird_Star, Cow_Star, Horse_Star, Llama_Star, Pig_Star, Pug_Star, Sheep_Star, Turkey_Star;

    private Transform originalPos;

    static public bool[] branded;

    // Update is called once per frame
    void Start()
    {
        branded = new bool[8];

        for (int i = 0; i < 8; i++)
        {
            branded[i] = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /* If an animal of a specific tag collides with the hand collider, then a new animal of the same kind is instantiated
         * and the original one is destroyed. The new animal will then set its destination to the player's hand, so it will
         * always follow the player.
         */

        if (collision.gameObject.tag == "bird")
        {
            newAnimal = Instantiate(Bird_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[0] = true;
        }

        if (collision.gameObject.tag == "cow")
        {
            newAnimal = Instantiate(Cow_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[1] = true;
        }

        if (collision.gameObject.tag == "horse")
        {
            newAnimal = Instantiate(Horse_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[2] = true;
        }

        if (collision.gameObject.tag == "llama")
        {
            newAnimal = Instantiate(Llama_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[3] = true;
        }

        if (collision.gameObject.tag == "pig")
        {
            newAnimal = Instantiate(Pig_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[4] = true;
        }

        if (collision.gameObject.tag == "dog")
        {
            newAnimal = Instantiate(Pug_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[5] = true;
        }

        if (collision.gameObject.tag == "sheep")
        {
            newAnimal = Instantiate(Sheep_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[6] = true;
        }

        if (collision.gameObject.tag == "turkey")
        {
            newAnimal = Instantiate(Turkey_Star, collision.gameObject.transform);
            Destroy(collision.gameObject.transform.GetChild(0).gameObject);
            branded[7] = true;
        }
    }
}