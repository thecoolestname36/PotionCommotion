using System;
using System.Web.Mvc;
using PotionCommotion.Components;

namespace PotionCommotion.Controllers {
    public class WebSocketController : Controller {
		public ActionResult Open() {
			// Early return if the request is not a web socket request
			try {

				string WSSID = System.Web.HttpContext.Current.User.Identity.Name + "_" + (Guid.NewGuid()).ToString();
				WebSocketManager.WebSockets.Add(
					WSSID,
					new WebSocket(WSSID)
				);
				WebSocketManager.WebSockets.TryGetValue(WSSID, out WebSocket socket);
				HttpContext.AcceptWebSocketRequest(
					socket.HandleSocket,
					socket.WebSocketOptions
				);

			} catch (Exception e) {
				return new HttpStatusCodeResult(500, "Internal Server Error: " + e.Message);
			}
			return new HttpStatusCodeResult(101, "Switching Protocol");

		}

	}

}
