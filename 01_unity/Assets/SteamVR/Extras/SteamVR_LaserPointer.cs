//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public struct PointerEventArgs
{
    public uint controllerIndex;
    public uint flags;
    public float distance;
    public Transform target;
}

public delegate void PointerEventHandler(object sender, PointerEventArgs e);


public class SteamVR_LaserPointer : MonoBehaviour
{
    public bool active = true;
    public Color color;
    public float thickness = 0.002f;
    public GameObject holder;
    public GameObject pointer;
    bool isActive = false;
    public bool addRigidBody = false;
    public Transform reference;
    public event PointerEventHandler PointerIn;
    public event PointerEventHandler PointerOut;
	public Text deu;
	public Text ind;
	public Text usa;
	public Text rus;
	public Text bra;
	public Text chi;
	public Text aus;
	public Text agy;
	private Text previousTxt;

    Transform previousContact = null;

	// Use this for initialization
	void Start ()
    {
    	previousTxt = deu;
        holder = new GameObject();
        holder.transform.parent = this.transform;
        holder.transform.localPosition = Vector3.zero;
		holder.transform.localRotation = Quaternion.identity;

		pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.transform.parent = holder.transform;
        pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
        pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
		pointer.transform.localRotation = Quaternion.identity;
		BoxCollider collider = pointer.GetComponent<BoxCollider>();
        if (addRigidBody)
        {
            if (collider)
            {
                collider.isTrigger = true;
            }
            Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        else
        {
            if(collider)
            {
                Object.Destroy(collider);
            }
        }
        Material newMaterial = new Material(Shader.Find("Unlit/Color"));
        newMaterial.SetColor("_Color", color);
        pointer.GetComponent<MeshRenderer>().material = newMaterial;
	}

    public virtual void OnPointerIn(PointerEventArgs e)
    {
        if (PointerIn != null)
            PointerIn(this, e);
    }

    public virtual void OnPointerOut(PointerEventArgs e)
    {
        if (PointerOut != null)
            PointerOut(this, e);
    }


    // Update is called once per frame
	void Update ()
    {
        if (!isActive)
        {
            isActive = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        float dist = 100f;

        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);


        if(previousContact && previousContact != hit.transform)
        {
            PointerEventArgs args = new PointerEventArgs();
            if (controller != null)
            {
                args.controllerIndex = controller.controllerIndex;
            }
            args.distance = 0f;
            args.flags = 0;
            args.target = previousContact;
            OnPointerOut(args);
            previousContact = null;
        }
        if(bHit && previousContact != hit.transform)
        {
            PointerEventArgs argsIn = new PointerEventArgs();
            if (controller != null)
            {
                argsIn.controllerIndex = controller.controllerIndex;
            }
            argsIn.distance = hit.distance;
            argsIn.flags = 0;
            argsIn.target = hit.transform;
            OnPointerIn(argsIn);
            previousContact = hit.transform;

            switch (hit.collider.tag) {
            	case "Deutschland": 
            		Debug.Log("DE");
					previousTxt.enabled = false;
            		deu.enabled = true;
            		previousTxt = deu;
            		break;
            	case "Indien": 
            		Debug.Log("IND");
					previousTxt.enabled = false;
					ind.enabled = true;
            		previousTxt = ind;
            		break;
            	case "USA": 
            		Debug.Log("USA");
					previousTxt.enabled = false;
					usa.enabled = true;
            		previousTxt = usa;
            		break;
            	case "Russland": 
            		Debug.Log("RUS");
					previousTxt.enabled = false;
					rus.enabled = true;
            		previousTxt = rus;
            		break;
            	case "Brasilien": 
            		Debug.Log("BRA");
            		previousTxt.enabled = false;
					bra.enabled = true;
            		previousTxt = bra;
            		break;
            	case "China": 
            		Debug.Log("CHI");
            		previousTxt.enabled = false;
					chi.enabled = true;
            		previousTxt = chi;
            		break;
            	case "Australien": 
            		Debug.Log("AUS");
            		previousTxt.enabled = false;
					aus.enabled = true;
            		previousTxt = aus;
            		break;
            	case "Agypten": 
            		Debug.Log("AGY");
            		previousTxt.enabled = false;
					agy.enabled = true;
            		previousTxt = agy;
            		break;
            	default: 
            		previousTxt.enabled = false;
            		break;
            }


        }


        if(!bHit)
        {
            previousContact = null;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }

        if (controller != null && controller.triggerPressed)
        {
            pointer.transform.localScale = new Vector3(thickness * 5f, thickness * 5f, dist);
        }
        else
        {
            pointer.transform.localScale = new Vector3(thickness, thickness, dist);
        }
        pointer.transform.localPosition = new Vector3(0f, 0f, dist/2f);
    }



}
