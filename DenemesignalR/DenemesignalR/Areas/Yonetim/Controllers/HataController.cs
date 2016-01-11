using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DenemesignalR.Areas.Yonetim.Models;
using Microsoft.AspNet.SignalR;

namespace DenemesignalR.Areas.Yonetim.Controllers
{
    [UserFilter]
    public class HataController : Controller
    {
        // GET: Yonetim/Hata
        public ActionResult Index()
        {
            return View();
        }

        public class GamesHub : Hub
        {
            public static SignalRDenemeEntities db = new SignalRDenemeEntities();

            public override async System.Threading.Tasks.Task OnConnected()
            {
                if (Context.QueryString["isWebUser"] == "true")
                {
                    var data = db.sayacHata();
                    await Clients.Caller.getAllProduct(data);
                }
            }

            public override async Task OnReconnected()
            {
                await OnConnected();
            }

            public void RefreshData(int ID)
            {
                var changeData = db.sayacHataIdProp(ID);
                Clients.All.refreshData(changeData);
            }
        }
    }
}