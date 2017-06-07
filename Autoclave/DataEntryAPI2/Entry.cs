using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataEntryAPI
{
    public class Entry
    {
        public async static Task<EntryImporterWebResponse> EntryImporter(EntryImporterWebRequest request)
        {
            string json = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(request));
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            Console.WriteLine("Created HTTP Content:");
            Console.WriteLine(json);
            Console.WriteLine();

            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("POST ..." + "http://www.lotteryhub.com/api/services/tw_data_importer.php");

                var httpResponse = await client.PostAsync("http://www.lotteryhub.com/api/services/tw_data_importer.php", httpContent);

                Console.WriteLine("Response recieved: " + httpResponse.StatusCode + " [" + (int)httpResponse.StatusCode + "]");

                if(httpResponse.Content != null)
                {
                    string response = await httpResponse.Content.ReadAsStringAsync();

                    EntryImporterWebResponse Concrete = JsonConvert.DeserializeObject<EntryImporterWebResponse>(response);

                    return Concrete;
                }
            }

            return new EntryImporterWebResponse
            {
                success = "false",
                message = "Failed to get content"
            };
        }
    }

    public class EntryImporterWebRequest
    {
        public string data_key { get; set; }
        public EntryImporterDrawData[] draw_data { get; set; }

        public class EntryImporterDrawData
        {
            public UInt32 lottery_id { get; set; }
            public string[] picks { get; set; }
            public string[] specials { get; set; }
            public string multiplier { get; set; }
            public string draw_date { get; set; }
        }
    }

    public class EntryImporterWebResponse
    {
        public string success { get; set; }
        public string message { get; set; }
    }
}
