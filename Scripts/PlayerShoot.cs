using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    bool fire = false;
    public bool lefthand = false;
    public AudioSource gunsound;
    public AudioClip gunshot;
    public GameObject mflash;
    public GameObject mflashOrigin;


    void Update()
    {

        float triggerleft = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float triggerright = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);

        
        if (!lefthand)

        {

            if (triggerright > 0.9f && fire == false)
            {
                fire = true;

                GameObject ball = Instantiate(projectile, transform.position,
                                                          transform.rotation);
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                     (0, 0, launchVelocity));
                gunsound.PlayOneShot(gunshot);

                Instantiate(mflash, mflashOrigin.transform.position, mflashOrigin.transform.rotation);

                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);

                StartCoroutine(StopVibrationR());

            }

        }

        if (lefthand)

        {

            if (triggerleft > 0.9f && fire == false)
            {
                fire = true;

                GameObject ball = Instantiate(projectile, transform.position,
                                                          transform.rotation);
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                     (0, 0, launchVelocity));
                gunsound.PlayOneShot(gunshot);

                Instantiate(mflash, mflashOrigin.transform.position, mflashOrigin.transform.rotation);

                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);

                StartCoroutine(StopVibrationL());




            }

        }
        

        IEnumerator StopVibrationR()
        {
            yield return new WaitForSeconds(0.2f); // waits before continuing in seconds

            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

            yield return new WaitForSeconds(0.2f); // waits before continuing in seconds

            fire = false;

            yield break;

        }

        IEnumerator StopVibrationL()
        {
            yield return new WaitForSeconds(0.2f); // waits before continuing in seconds

            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

            yield return new WaitForSeconds(0.2f); // waits before continuing in seconds

            fire = false;

            yield break;
            

        }
    }
}
