using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject PerspectiveCam;
    public GameObject OrthographicCam;
    public static int CamMode = 1;
		[SerializeField] int StartCamMode;

		// Start is called before the first frame update
    void Start()
    {
        CamMode = StartCamMode;
    }

    // Update is called once per frame
    void Update ()
    {
			StartCoroutine(CamChange());

	    if(Input.GetButtonDown ("Camera")) {
	      if(CamMode == 1) {
	          CamMode = 0;
	      }
	      else {
	          CamMode += 1;
	      }
	    }
    }

    public IEnumerator CamChange () {
        yield return new WaitForSeconds(0.01f);

        if(CamMode == 1) {
            PerspectiveCam.SetActive(true);
            OrthographicCam.SetActive(false);
						GameObject.Find("Button").GetComponent<Collider>().isTrigger = true;
						GameObject.Find("Button (2)").GetComponent<Collider>().isTrigger = true;
						GameObject.Find("Button (3)").GetComponent<Collider>().isTrigger = true;
						GameObject.Find("Button (4)").GetComponent<Collider>().isTrigger = true;
            // GameObject.Find("Button").transform.position = new Vector3(15, 15, 15);
						// GameObject.Find("Button").transform.Translate(0, 200, 0);
        }

        if(CamMode == 0) {
            OrthographicCam.SetActive(true);
            PerspectiveCam.SetActive(false);
            // GameObject.Find("Button").transform.position = new Vector3(8, 6, -10);
						GameObject.Find("Button").GetComponent<Collider>().isTrigger = false;
						GameObject.Find("Button (2)").GetComponent<Collider>().isTrigger = false;
						GameObject.Find("Button (3)").GetComponent<Collider>().isTrigger = false;
						GameObject.Find("Button (4)").GetComponent<Collider>().isTrigger = false;
        }
    }
}
