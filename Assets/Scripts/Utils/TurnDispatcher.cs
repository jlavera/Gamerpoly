using Assets.Scripts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Utils {
    public class TurnDispatcher {//: IEnumerator<Player> {

        private Player[] Players;

        public TurnDispatcher(Player[] _players) {
            Players = _players;
            position = 0;
            //actual = 0;
        }

        //private int actual;
        //public Player Current { get { return Players[actual]; } }

        //public bool MoveNext() {
        //    actual = ++actual % Players.Length;
        //    return true;
        //}

        //public void Reset(){
        //    actual = 0;
        //}

        private int position;

        public Player NextPlayer {
            get { return Players[++position % Players.Length]; }
        }
    }
}