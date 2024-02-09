using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] public Transform[] cropStages;
    private float growthRate = 8f;
    private bool isReady = false;
    

    private void Awake()
    {
        StartCoroutine(Grow());
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Grow()
    {
        cropStages[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(growthRate);
        cropStages[1].gameObject.SetActive(true);
        cropStages[0].gameObject.SetActive(false);
        isReady = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReady)
        {
            Destroy(gameObject);
            Debug.Log("Harvester collides with Crop");
        }
    }
}
