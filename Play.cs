using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour
{
    public float rayLenght;
    public LayerMask layermask;
    public Animator anim;
    bool counter = true;

    void Start() {

    }
    
    public void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) //touch input detected
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, rayLenght, layermask)) //if we hit something:
            {
                Debug.Log(hit.collider.name); //log the name of the hit object
                string objectName = hit.collider.name;
                
                if (objectName == "Plant" && counter == true) //start animation if Plant is hit
                {
                    Debug.Log("plant is hit");
                    anim.Play("Grow");
                    counter = false;
                } else if (objectName == "Plant" && counter == false) //stop animation on every 2th touch
                {
                    Debug.Log("back to default");
                    anim.Play("Default");
                    counter = true;
                }             
            }
        }
    }
}