using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bk_materialChanger : MonoBehaviour
{
    public Button[] listofButtonImages;
	// Use this for initialization
	void Start ()
    {
        //print("The name of this shit material is: "+gameObject.GetComponent<Renderer>().materials[4].name);
        //gameObject.GetComponent<Renderer>().materials[4].color = Color.blue;
        //listofButtonImages[0].GetComponent<Image>().color = Color.green;
        //listOfMaterials = gameObject.GetComponent<MeshRenderer>().materials;

        //for(int i=0;i<5;i++)
        //{
        //    listOfMaterials[i]= myMat;
        //}

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void setIndicator(int unitNumber)
    {
        switch(unitNumber)
        {
            case 0:
                listofButtonImages[1].GetComponent<Image>().color = Color.yellow;
                gameObject.GetComponent<Renderer>().materials[4].color = Color.yellow;
                break;
            case 1:
                listofButtonImages[2].GetComponent<Image>().color = Color.red;
                gameObject.GetComponent<Renderer>().materials[4].color = Color.red;
                break;
            case 2:
                listofButtonImages[3].GetComponent<Image>().color = Color.blue;
                gameObject.GetComponent<Renderer>().materials[4].color = Color.blue;
                break;
            case 3:
                listofButtonImages[0].GetComponent<Image>().color = Color.green;
                gameObject.GetComponent<Renderer>().materials[4].color = Color.green;
                break;
        }
    }
}
