using MapleSugar.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MapleSugar.Services
{
    public class CheckListService
    {
        //private static string _treesJson = "[\n   {\n        \"Sector\":\"2\", \n        \"TreeNumber\":\"1\",\n        \"TapTube\":\"0\",\n        \"Circumference\":\"32.00\",\n        \"TreeCombineWith\":\"0\",\n        \"GridY\":\"10.00\",\n        \"GridX\":\"36.00\",\n        \"LatSec\":\"42.70\",\n        \"LonSec\":\"16.06\",\n        \"TreeSubLetter\":\"A\",\n        \"TreeLocation\":\"1\",\n        \"Container\":\"G\"\n    },\n   {\n        \"Sector\":\"1\", \n        \"TreeNumber\":\"1\",\n        \"SubTreeNumber\":\"1\",\n        \"ReprintTag\":\"0\",\n        \"Circumference\":\"19.00\",\n        \"TreeCombineWith\":\"0\",\n        \"GridY\":\"12.00\",\n        \"GridX\":\"36.50\",\n        \"LatSec\":\"42.70\",\n        \"LonSec\":\"16.48\",\n        \"TreeSubLetter\":\"A\",\n        \"TreeLocation\":\"1\",\n        \"Container\":\"S\"\n    }\n]";
        // private static string _treesJson = "{"Sector": "1","TreeNumber":"1","TapTube":"0","Circumference":"32.00","TreeCombineWith":"0","GridY":"10.00","GridX":"36.00","LatSec":"42.70","LonSec":"16.06","TreeSubLetter":"A","TreeLocation":"1","Container":"G"},{"Sector":"1","TreeNumber":"1","SubTreeNumber":"1","ReprintTag":"0","Circumference":"19.00","TreeCombineWith":"0","GridY":"12.00","GridX":"36.50","LatSec":"42.70","LonSec":"16.48",TreeSubLetter":"A","TreeLocation":"1","Container":"S"} " ;

        public static List<CheckListItem> GetSTrees(string _treesJson)
        {
            return JsonConvert.DeserializeObject<List<CheckListItem>>(_treesJson);
        }       
    }
}
