using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    // Creating a NavMeshAgent object to allow the animal object to move around the terrain
    protected NavMeshAgent animal;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponent<NavMeshAgent>();
        animal.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        animal.SetDestination(GameObject.Find("OVRPlayerController").transform.position);


        // If the branded bool variable from the TouchedObject class is true, then the animal will always follow the user
        if (TouchedObject.branded[0] && gameObject.name == "Bird_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[1] && gameObject.name == "Cow_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[2] && gameObject.name == "Horse_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[3] && gameObject.name == "Llama_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[4] && gameObject.name == "Pig_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[5] && gameObject.name == "Pug_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[6] && gameObject.name == "Sheep_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }

        if (TouchedObject.branded[7] && gameObject.name == "Turkey_Star(Clone)")
        {
            animal.SetDestination(GameObject.Find("Player").transform.position);
        }
    }
}
