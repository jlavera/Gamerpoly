using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameSystem : MonoBehaviour
{
	private GameSystem m_Instance;
	public GameSystem Instance { get { return m_Instance; } }
	public Tile[] Tiles;
	
	void Awake()
	{
		m_Instance = this;
		Tiles = new Tile[40];
		
		for (int r=0; r<4; r++)
			for (int i=0; i<10; i++) 
				Tiles [r*10+i] = new Tile (GameObject.Find("Row"+r+"/tile"+i));
		
		GameObject.Find ("pjCono").transform.position = Tiles [25].Position;
	}
	
	void OnDestroy()
	{
		m_Instance = null;
	}
	

	void Update()
	{
		// global game update logic goes here
	}
	
	void OnGui()
	{
		// common GUI code goes here
	}
	
}