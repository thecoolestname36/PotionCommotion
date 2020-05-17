Socket = function (endpoint, protocol) {

	this.Endpoint = endpoint;
	this.Protocol = protocol;
	this.Context = null;
	this.OnOpen = function (event) { };
	this.OnClose = function (event) { };
	this.OnReset = function (content) { };
	this.OnSelected = function (content) { };
	this.OnMessage = function (message) {
		var serverMessage = new ServerMessage(JSON.parse(message.data));
		switch (serverMessage.Command) {
			case ServerCommands.Reset:
				this.onreset(serverMessage.Content);
				break;
			case ServerCommands.Selected:
				this.onselected(serverMessage.Content);
				break;
			case ServerCommands.Error:
				console.error(serverMessage.Content);
				break;
		}
	};
	this.SendMessage = function (message) {
		this.Context.send(JSON.stringify(message));
	};
	this.InitContext = function() {
		this.Context = new WebSocket(this.Endpoint, this.Protocol);
		this.Context.onopen = this.OnOpen;
		this.Context.onclose = this.OnClose;
		this.Context.onmessage = this.OnMessage;
		this.Context.onreset = this.OnReset;
		this.Context.onselected = this.OnSelected;
	};

};
