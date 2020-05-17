using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.WebSockets;
using System.Net.WebSockets;
using PotionCommotion.Models;

namespace PotionCommotion.Components {
	public class WebSocket {

		public AspNetWebSocketContext Context;
		public AspNetWebSocketOptions WebSocketOptions;
		public string WSSID;

		public WebSocket(string WSSID) {
			this.WSSID = WSSID;
			this.WebSocketOptions = new AspNetWebSocketOptions()
			{
				SubProtocol = "potioncommotion",
				RequireSameOrigin = true
			};
		}

		public bool IsOpen() {
			return this.Context.WebSocket.State == WebSocketState.Open;
		}

		public async Task HandleSocket(AspNetWebSocketContext socketContext) {
			
			this.Context = socketContext;

			SpinWait.SpinUntil(() => this.IsOpen());

			await Task.Run(() => ReceiveThread());

			System.Diagnostics.Debug.WriteLine("Transmissions complete, end thread");
			// Transmissions complete, end thread
		}

		public void ReceiveThread() {
			while (this.IsOpen()) {
				try {
					string ms = this.GetMessage();
					if (ms.Length > 0) {
						ClientMessage message = Json.Decode<ClientMessage>(ms);
						if (message != null) {
							switch (message.Command) {
								// Define new commands in the ClientMessage.Commands and Scripts/Components/ClientCommands.js
							}
						}
					}
				} catch (Exception e) {
					this.SendServerError(e);
				}
			}

			// Clean up
			WebSocketManager.WebSockets.Remove(this.WSSID);
		}

		public string GetMessage() {
			bool complete = false;
			string message = "";
			while (!complete && this.IsOpen()) {
				ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[WebSocketManager.BUFFER_SIZE]);
				Task<WebSocketReceiveResult> result = this.Context.WebSocket.ReceiveAsync(buffer, CancellationToken.None);
				result.Wait();
				if (this.IsOpen()) {
					for (int i = 0, max = WebSocketManager.BUFFER_SIZE; i < max; i++) {
						byte b = buffer.Array[i];
						if (b > 0) {
							message += (char)buffer.Array[i];
						}
					}
				}
				complete = result.Result.EndOfMessage;
			}
			return message;
		}

		public void SendServerError(Exception e) {
			this.SendMessage(Json.Encode(
				new ServerMessage {
					Command = ServerMessage.Commands.Error,
					Contents = new Dictionary<string, string>(1)
					{
						{ "message", e.Message }
					}
				}
			));
		}

		public Task SendMessage(ServerMessage message, WebSocketMessageType type = WebSocketMessageType.Text, bool endOfMessage = true) =>
			SendMessage(Encoding.UTF8.GetBytes(Json.Encode(message)), type, endOfMessage);

		public Task SendMessage(string message, WebSocketMessageType type = WebSocketMessageType.Text, bool endOfMessage = true) =>
			SendMessage(Encoding.UTF8.GetBytes(message), type, endOfMessage);

		public Task SendMessage(byte[] message, WebSocketMessageType type = WebSocketMessageType.Text, bool endOfMessage = true) {
			ArraySegment<byte> messageSegment = new ArraySegment<byte>(message);
			if (this.Context.WebSocket.State == WebSocketState.Open) {
				return this.Context.WebSocket.SendAsync(
					messageSegment,
					type,
					endOfMessage,
					CancellationToken.None
				);
			} else {
				return Task.Run(() => { });
			}
		}

	}

}
