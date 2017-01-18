using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawner_list : MonoBehaviour
{
    public gotocenter[] objects;
    public Vector3 spawnpoint = new Vector3(0, 0, 0);
    private List<GameObject> spawned = new List<GameObject>();
    private Color lightcol;

    void Start()
    {
        lightcol = Color.green * 0.7f;
        StartCoroutine(spawn());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            for (var i = 0; i < spawned.Count; i++)
            {
                if (spawned[i] == null)
                    return;
                spawned[i].GetComponent<Rigidbody>().AddExplosionForce(50.0f, Vector3.zero, 20.0f, 0.0f, ForceMode.Impulse);
                spawned[i].GetComponent<gotocenter>().enabled = false;
                Destroy(spawned[i], Random.Range(1.0f, 3.0f));
            }
            spawned = new List<GameObject>();
            lightcol = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            spawnpoint = Random.onUnitSphere * Random.Range(10, 10 + 0.5f * Time.timeSinceLevelLoad);
            gotocenter nr = objects[Random.Range(0, objects.Length - 1)];
            var go = Instantiate(nr, spawnpoint, Quaternion.identity);
            var l = go.GetComponent<Light>();
            if (l != null)
            {
                l.color = lightcol;
            }
            spawned.Add(go.gameObject);
        }
    }
}
