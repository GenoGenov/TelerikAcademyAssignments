namespace Artists.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;

    using Artists.Models;

    using Newtonsoft.Json;

    internal class Program
    {
        private static void Main(string[] args)
        {
            //I know the update and delete are missing, but i have a teamwork to work on :D + this Web API is so easy...

            var client = new HttpClient { BaseAddress = new Uri("http://localhost:62315/") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CreateSong(client);
            GetAllSongs(client);

            Console.ReadKey();
        }

        private static void CreateSong(HttpClient client)
        {
            Console.WriteLine("Creating song..");

            var createSongMessage =
                client.PostAsync(
                                 "api/songs/create",
                                 new ObjectContent(
                                     typeof(Song),
                                     new Song() { Genre = "Pop", Title = "Shat na patkata glavata" },
                                     new JsonMediaTypeFormatter())).Result;

            Console.WriteLine("Creating song returned responce: {0}", createSongMessage.StatusCode);
        }

        private static async void GetAllSongs(HttpClient client)
        {
            var getAllSongsRequest = await client.GetAsync("api/songs/all");
            Console.WriteLine(
                              "Get all songs request returned response: {0}",
                              GetPrettyPrintedJson(getAllSongsRequest.Content.ReadAsStringAsync().Result));
        }

        private static string GetPrettyPrintedJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}