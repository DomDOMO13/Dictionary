using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict2.Service
{
    interface Idict
    {

        void addWord(string word, string meaning);
        List <string> getwords();


    }
}
