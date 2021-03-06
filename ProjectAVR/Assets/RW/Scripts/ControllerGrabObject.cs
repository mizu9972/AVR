﻿/*
 * Copyright (c) 2018 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject;
    private GameObject objectInHand;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gomi"|| other.gameObject.tag == "gomibako")
        {
            SetCollidingObject(other);
        }
        print("ごみごみ " + handType);
        if (other.gameObject.tag == "door")
        {
            FlagManager.Instance.flags[7] = true;
        }
        if (other.gameObject.tag == "door1")
        {
            FlagManager.Instance.flags[1] = true;
        }
        if (other.gameObject.tag == "door2")
        {
            FlagManager.Instance.flags[2] = true;
        }
        if (other.gameObject.tag == "door3")
        {
            FlagManager.Instance.flags[3] = true;
        }
        if (other.gameObject.tag == "tiku")
        {
            FlagManager.Instance.flags[66] = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "gomi"|| other.gameObject.tag == "gomibako")
        {
            SetCollidingObject(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        if (other.gameObject.tag == "door")
        {
            FlagManager.Instance.flags[7] = false;
        }
        if (other.gameObject.tag == "door1")
        {
            FlagManager.Instance.flags[1] = false;
        }
        if (other.gameObject.tag == "door2")
        {
            FlagManager.Instance.flags[2] = false;
        }
        if (other.gameObject.tag == "door3")
        {
            FlagManager.Instance.flags[3] = false;
        }
        if (other.gameObject.tag == "tiku")
        {
            FlagManager.Instance.flags[66] = false;
        }

        collidingObject = null;
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            FlagManager.Instance.flags[20] = true;
            if (collidingObject)
            {
                GrabObject();
                FlagManager.Instance.flags[5] = true;
            }
        }

        if (grabAction.GetLastStateUp(handType))
        {
            FlagManager.Instance.flags[20] = false;
            if (objectInHand)
            {
                ReleaseObject();
                FlagManager.Instance.flags[5] = false;
            }
        }
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
    }
}
