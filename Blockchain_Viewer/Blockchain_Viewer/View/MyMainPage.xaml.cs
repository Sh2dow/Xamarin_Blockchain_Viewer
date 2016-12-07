using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using Blockchain_Viewer.Model;

namespace Blockchain_Viewer.View
{
    public partial class MyMainPage : ContentPage
    {

        static ListView listview;
        static Button button;
        public MyMainPage()
        {
            listview = new ListView() { RowHeight = 40 };
            button = new Button() { Text = "Refresh" };
            var stack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { listview, button },
            };
            button.Clicked += (sender, args) =>
            {
                GetData();
            };
            Content = stack;
            GetData();
        }

        async static void GetData()
        {
            var result = new List<string>();
            try
            {
                var bi = new List<BlockchainDetail>();
                string json = await new HttpClient().GetStringAsync("https://blockchain.info/ticker");
                var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                foreach (var item in data.Values)
                {
                    bi.Add(new BlockchainDetail
                    {
                        Symbol = item["symbol"],
                        Buy = item["buy"],
                        Sell = item["sell"],
                        Last = item["last"]
                    });
                }
                listview.ItemsSource = bi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}