using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict2.Service
{
    class Dict : Idict
    {
        public void addWord(string word, string meaning)
        {
            this._words.Add(word, meaning); 
        }

        public List<string> getwords()
        {
            return this._words.Keys.ToList();
        }

        private Dictionary<string, string> _words = new Dictionary<string, string>();
    }
}
