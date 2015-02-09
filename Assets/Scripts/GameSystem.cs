using UnityEngine;
using System.Collections;
using Assets.Scripts.Utils;
using Assets.Scripts.Domain;

public class GameSystem : MonoBehaviour {

    static private GameSystem m_Instance;
    static public GameSystem Instance {
        get {
            if (m_Instance == null)
                m_Instance = new GameSystem();
            return m_Instance;
        }
    }

    public Tile[] Tiles;
    public Player[] Players;
	public Player NextPlayer;

    public TurnDispatcher Turns;

    void Awake() {
        m_Instance = this;

        //--Build array with positions (planes)
        Tiles = new Tile[40];
        for (int r = 0; r < 4; r++)
            for (int i = 0; i < 10; i++)
                Tiles[r * 10 + i] = new Tile(GameObject.Find("Row" + r + "/tile" + i));

        //--Build array with players
        Players = new Player[3];
        Players[0] = new Player("Gatito", TokenFactory.Tokens.Cono);
    //    Players[1] = new Player("Catty", TokenFactory.Tokens.Dona);
    //    Players[2] = new Player("Cat", TokenFactory.Tokens.Tetera);

        //--Build enumerator to cycle the player/turns
        Turns = new TurnDispatcher(Players);

        NextPlayer = Turns.NextPlayer; //--This is the next player
		
    }

    void OnDestroy() {
        m_Instance = null;
    }


    void Update() {
        // global game update logic goes here
    }

    void OnGui() {
        // common GUI code goes here
    }

}