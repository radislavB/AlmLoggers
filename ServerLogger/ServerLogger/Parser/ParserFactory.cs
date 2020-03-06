using System;
using System.Collections.Generic;
using System.IO;

namespace ServerLogger.Parser
{
    public class ParserFactory
    {
        List<ParserBase> listParser;

        public ParserFactory()
        {
            listParser = new List<ParserBase>();

            listParser.Add(new Parser1500());
            listParser.Add(new Parser1500SA());
            listParser.Add(new Parser1260());
            listParser.Add(new Parser1255());
            listParser.Add(new Parser1200());
            listParser.Add(new Parser1200SA());
            listParser.Add(new Parser1152ALM());
            listParser.Add(new Parser1152SA());
            listParser.Add(new Parser1000());
            listParser.Add(new Parser1100());
            listParser.Add(new Parser1100Patch10());
            listParser.Add(new Parser0900());
            listParser.Add(new Parser0920());
            listParser.Add(new Parser0920SA());
            listParser.Add(new Parser1100SA());
            listParser.Add(new Parser1000SA());
            listParser.Add(new Parser0900SA());
            listParser.Add(new Parser0920_Ex());
            listParser.Add(new Parser0920SA_Ex());
        }
        public ParserBase GetParser(string fileName, IList<string> lines)
        {
            foreach (ParserBase parser in listParser)
            {
                if (parser.IsValidLog(lines))
                    return parser;
            }
            throw new ApplicationException(string.Format("File <{0}> isn't supported by application.", Path.GetFileName(fileName)));
        }
    }

}
