using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class HoldToLoadLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float holdDuration = 1f;
    public Image fillCircle;

    private float holdTimer = 0;
    private bool isHolding = false;

    public static event Action onHoldComplete;

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            fillCircle.fillAmount = holdTimer/holdDuration;
            if(holdTimer >= holdDuration)
            {
                onHoldComplete.Invoke();
            }
        }
    }

    public void onHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
        } else if(context.canceled) {
            resetHold();
        }
    }

    private void resetHold()
    {
        isHolding = false;
        holdTimer= 0;
        fillCircle.fillAmount = 0;
    }
}
