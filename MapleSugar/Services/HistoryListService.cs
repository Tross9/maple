using MapleSugar.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MapleSugar.Services.Navigation
{
    public class HistoryListService
    {
        public static List<HistoryListItem> GetSHistory(string _HistoryJson)
        {
            return JsonConvert.DeserializeObject<List<HistoryListItem>>(_HistoryJson);
        }
    }
}
