using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour {

	public static SelectionController Instance;
	public GameObject selected;

	public GameObject nexusPanel;
	public GameObject reaperPanel;


	void Awake()
	{
		Instance = this;
	}

	public void SetSelection(GameObject selected)
	{
		this.selected = selected;

		if (selected.tag == "Reaper")
		{
			DisableContextPanels ();
			reaperPanel.SetActive (true);
		}

		if (selected.tag == "Nexus")
		{
			DisableContextPanels ();
			nexusPanel.SetActive (true);
		}
	}

	public void DisableContextPanels()
	{
		nexusPanel.SetActive (false);
		reaperPanel.SetActive (false);

	}

	public GameObject GetSelection()
	{
		return selected;
	}

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}
}
