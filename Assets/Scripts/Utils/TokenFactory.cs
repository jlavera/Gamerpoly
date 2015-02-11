using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils {
    public static class TokenFactory {

        public enum Tokens { Cono, Dona, Tetera }

        private static Dictionary<Tokens, string> dict = new Dictionary<Tokens, string>(){
			{Tokens.Cono, ObjMan.TokenCono},
			{Tokens.Dona, ObjMan.TokenDona},
			{Tokens.Tetera, ObjMan.TokenTetera}
		};

        public static GameObject Get(Tokens tok) {
            var aux = GameObject.Find(dict[tok]);
            if (aux == null)
                throw new Exception("tok not found " + dict[tok]);
            return aux;
        }

    }
}