using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils {
    public static class TokenFactory {

        public enum Tokens { Cono, Dona, Tetera}

		private static Dictionary<Tokens, string> dict = new Dictionary<Tokens, string>(){
			{Tokens.Cono, "pjCono"},
			{Tokens.Dona, "pjDona"},
			{Tokens.Tetera, "pjTetera"}
		};

        public static GameObject Get(Tokens tok) {
            //return GameObject.Find(dict[tok]);
			var aux = GameObject.Find (dict [tok]);
			if (aux == null)
				throw new Exception ( "tok not found " + dict[tok]);
			return aux;
        }

    }
}
