using UnityEngine;
using System.Collections;
using Assets.Scripts.Utils;
using Assets.Scripts.Domain;

public class GameSystem : MonoBehaviour {

    private GameSystem m_Instance;
    public GameSystem Instance { get { return m_Instance; } }

    public Tile[] Tiles;
    public Player[] Players;

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
        Players[1] = new Player("Quique", TokenFactory.Tokens.Dona);
        Players[2] = new Player("Bogdan", TokenFactory.Tokens.Tetera);

        //--Build enumerator to cycle the player/turns
        Turns = new TurnDispatcher(Players);

        var play = Turns.NextPlayer; //--This is the next player

        //GameObject.Find("pjCono").transform.position = Tiles[25].Position;
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