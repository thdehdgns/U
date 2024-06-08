using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("รั")]
    public GameObject BullitPrefab;
    public Transform spawnposition;
    public Transform endpos;
    public float Delay = 1.0f;
    public bool asdf = true;


    public void Start()
    {
        SpawnPrefab();
    }

    public void Update()
    {
        if(asdf == true)
        {
            SpawnPrefab();
        }
         
    }

    IEnumerator Stop()
    {
        asdf = false;
        yield return new WaitForSeconds(Delay);
        asdf = true;
    }

    private void SpawnPrefab()
    {
        GameObject bullit = Instantiate(BullitPrefab, spawnposition.transform.position, Quaternion.identity);
        Bullit bullitCtrl = bullit.GetComponent<Bullit>();
        bullitCtrl.movePistions[0] = spawnposition;
        bullitCtrl.movePistions[1] = endpos;
        StartCoroutine(Stop());
    }
}
