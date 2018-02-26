using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MeteoProg
{
   public class Parser
    {
        public void Pars()
        {
            var html = @"https://ua.sinoptik.ua/погода-львів";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"bd1c\"]/div[1]/div[1]/div[1]/p[2]");
            

            string pattern = @" \d";
            var input = node.InnerText;

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }


            var t = 10 - 1;
        }
    }
}
