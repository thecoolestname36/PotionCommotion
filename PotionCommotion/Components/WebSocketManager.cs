using System;
using System.Collections.Generic;
using PotionCommotion.Models;

namespace PotionCommotion.Components {
	public class WebSocketManager {
		public static int CollectionConcurrency;
		public static Dictionary<string, WebSocket> WebSockets;
		public static Random Rand;
		public const int BUFFER_SIZE = 510; // Needs to be a multiple of 3 for the base64 encoding result on the other side.

		public WebSocketManager() {
			WebSocketManager.CollectionConcurrency =  Environment.ProcessorCount * 2;
			WebSocketManager.WebSockets = new Dictionary<string, WebSocket>();
			WebSocketManager.Rand = new Random();
		}

		public static void Broadcast( ServerMessage message ) {

			foreach (var socket in WebSockets.Values) {
				socket.SendMessage(message);
			}
		
		}
		
	}

}
