using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzechCases.Model
{
    public class Word
    {
        public Word(WordAllCases wordCases, GrammaticalGender gender)
        {
            WordCases = wordCases;
            Gender = gender;
        }

        public WordAllCases WordCases { get; }
        public GrammaticalGender Gender { get; }
    }
}
