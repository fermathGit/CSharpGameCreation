using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameLoop {
    public class FontParser {
        static int HeaderSize = 4;

        static int GetValue( string s ) {
            string value = s.Substring( s.IndexOf( '=' ) + 1 );
            return int.Parse( value );
        }

        public static Dictionary<char, CharacterData> Parse( string filePath ) {
            Dictionary<char, CharacterData> charDictionary = new Dictionary<char, CharacterData>();
            string[] lines = File.ReadAllLines( filePath );
            for ( int i = HeaderSize; i < lines.Length; ++i ) {
                string firstLine = lines[i];
                string[] typesAndValues = firstLine.Split( " ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries );

                CharacterData charData = new CharacterData {
                    ID = GetValue( typesAndValues[1] ),
                    X = GetValue( typesAndValues[2] ),
                    Y = GetValue( typesAndValues[3] ),
                    Width = GetValue( typesAndValues[4] ),
                    Height = GetValue( typesAndValues[5] ),
                    XOffset = GetValue( typesAndValues[6] ),
                    YOffset = GetValue( typesAndValues[7] ),
                    XAdvance = GetValue( typesAndValues[8] )
                };
                charDictionary.Add( (char)charData.ID, charData );
            }
            return charDictionary;
        }
    }
}
