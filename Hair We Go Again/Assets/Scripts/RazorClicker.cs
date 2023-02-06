using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RazorClicker : MonoBehaviour
{
    private float razorCounter;
    private float razorAdder;
    private Vector3 pos;

    public GameObject hairFlipParticles;

    void Start()
    {
        razorCounter = 0f;
        razorAdder = 5f;

        pos = new Vector3(-10, -8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Razor charge: " + RazorSlider.charge);
    }

    public void RazorClickFunc()
    {
        razorCounter = razorCounter + razorAdder;
        RazorSlider.charge -= RazorSlider.chargeDeductor;
        Instantiate(hairFlipParticles, pos, Quaternion.identity);
        //Destroy(hairFlipParticles);
    }
}
