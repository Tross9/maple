using MapleSugar.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MapleSugar.Services
{
    class FilterListService
    { 
            public static List<FilterList> GetSTrees(string _treesJson)
            {
                return JsonConvert.DeserializeObject<List<FilterList>>(_treesJson);
            }
        }
    }
