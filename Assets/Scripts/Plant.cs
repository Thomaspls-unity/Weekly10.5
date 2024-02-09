using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Plant : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent plantAgent;
    [SerializeField] private GameObject cropToPlant;

    public bool isPlanting = false;
    public bool isUnitMoving = false;

    private Vector3 plantPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlantMove();

        if (isUnitMoving)
        {
            Debug.Log("Unit currently unavailable");
            if (plantAgent.remainingDistance < 0.1f)
            {
                isUnitMoving = false;
                isPlanting = false;
            }
        }
        else
        {
            if (Vector3.Distance(plantAgent.transform.position, plantPosition) < 0.1f && !isPlanting)
            {
                PlantCrop();
            }
        }
    }

    private void PlantCrop()
    {
        if (!isPlanting && !isUnitMoving)
        {
            Instantiate(cropToPlant, plantPosition, Quaternion.identity);
            isPlanting = true;
        }
    }

    private void PlantMove()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                plantAgent.SetDestination(hit.point);
                plantPosition = hit.point;
                isUnitMoving = true;
            }
        }
    }
}
