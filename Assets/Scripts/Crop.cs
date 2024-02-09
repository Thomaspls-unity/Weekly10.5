using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public Transform[] cropStages;
    public float growthRate = 8f;
    public bool isReady = false;

    private void Awake()
    {
        StartCoroutine(Grow());
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            
        }
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
        
    }
}
