using FindPlayers.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//58d1a8cf-2b91-4146-9a36-5d9cb937b809 API KEY LEAGUE OF LEGENDS

namespace FindPlayers.StaticServices
{
    class GetAccountAsync {
        public static async Task<LoLAccount> GetLolAccountAsync(User credentials) {
            LoLAccount acc = new LoLAccount();
            var client = new RestClient("https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/");
            var request = new RestRequest("THANK%20YOU%20SIR" + "?api_key=RGAPI-d484dd57-61e9-47b5-a1c7-081449c086f3", Method.GET); //Indsæt DateTime.Now.Date.ToString("yyyy -MM-dd") - Bare for at teste det virker
            var cancellationTokenSource = new CancellationTokenSource();                                                                                                                                                                            //var request = new RestRequest("workplan/week?email=" + User.Username + "&password=" + User.Password + "&date=" + DateTime.Now.Date.ToString("yyyy-MM-dd"), Method.GET); //Indsæt DateTime.Now.Date.ToString("yyyy-MM-dd") - Bare for at teste det virker
            var respond = await client.ExecuteTaskAsync<LoLAccount>(request, cancellationTokenSource.Token);
            acc = respond.Data;

            var client1 = new RestClient("https://euw1.api.riotgames.com/tft/league/v1/entries/by-summoner/");
            var request1 = new RestRequest("" + acc.Id + "?api_key=RGAPI-d484dd57-61e9-47b5-a1c7-081449c086f3", Method.GET);
            var respond1 = await client.ExecuteTaskAsync<TFTRank>(request, cancellationTokenSource.Token);

            return acc;
        }
    }
}
