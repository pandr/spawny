using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawner_single : MonoBehaviour
{
    public GameObject blue_ball;
    public GameObject red_ball;
    public GameObject green_cube;
    public Vector3 spawnpoint = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            spawnpoint = Random.onUnitSphere * 10;
            Instantiate(blue_ball, spawnpoint, Quaternion.identity); // Laver en klon af Blue_ball
            spawnpoint = Random.onUnitSphere * 10;
            Instantiate(red_ball, spawnpoint, Quaternion.identity); // Laver en klon af Red_ball
            spawnpoint = Random.onUnitSphere * 10;
            Instantiate(green_cube, spawnpoint, Quaternion.identity); // Laver en klon af Blue_ball     
        }
    }
}
