using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace CallHataServices.Controllers
{
    public class HataLogController : ApiController
    {
        public string Get(int id)
        {
            try
            {
                Triger(id);
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async void Triger(int ID)
        {
            try
            {
                var hubConnection = new HubConnection("http://localhost:4381/Yonetim/Hata");
                IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("GamesHub");

                await hubConnection.Start(new LongPollingTransport());
                stockTickerHubProxy.Invoke("RefreshData", ID);
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }
    }
}
