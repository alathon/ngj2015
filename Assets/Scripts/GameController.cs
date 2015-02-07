using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject normalCam;
    public GameObject oculusBase;

	void Start ()
	{
        OVRManager.TrackingAcquired += OnOculusStart;
        OVRManager.TrackingLost += OnOculusEnd;
	    if (OVRManager.capiHmd != null)
	    {
	        OVRManager.DismissHSWDisplay(); // disable safety message
            OnOculusStart();
	    }
	    else
	    {
	        OnOculusEnd();
	    }
	}

    void OnDestroy()
    {
        OVRManager.TrackingAcquired -= OnOculusStart;
        OVRManager.TrackingLost -= OnOculusEnd;
    }

    private void OnOculusStart()
    {
        normalCam.SetActive(false);
        oculusBase.SetActive(true);
    }

    private void OnOculusEnd()
    {
        oculusBase.SetActive(false);
        normalCam.SetActive(true);
    }
}
