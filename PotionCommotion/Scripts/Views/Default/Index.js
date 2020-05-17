$(document).ready(function () {

	$('#potions-grid').data('Potions', new function() {

		// Define class methods
		this.HandlePotionClick = function(id) {
			$.ajax({
				cache: false,
				method: "GET",
				url: $('#potions-grid').data('selectpotionurl') + '/' + id,
				success: function(data) {
					if (data.Code == 200) {
						$('#potion-modal-body').text(data.Result);
						$('#potionModal').modal('show');
					}
				}
			});
		};

		// WSS Definition
		this.Socket = new Socket("wss://" + location.host + "/WebSocket/Open", "potioncommotion");
		this.Socket.OnOpen = function(event) {
			$.ajax({
				cache: false,
				method: "GET",
				url: $('#potions-grid').data('potionsgridurl'),
				success: function (data) {
					$('#potions-grid').html(data);
					$('.potion').on("click", function() {
						$('#potions-grid').data('Potions').HandlePotionClick($(this).data('id'));
					});
				}
			});
		};

		this.Socket.OnClose = function (event) {
			setTimeout(function () {
				$('#potions-grid').data('Potions').Socket.InitContext();
			}, 250);
		};

		this.Socket.OnReset = function(content) {
			$.ajax({
				cache: false,
				method: "GET",
				url: $('#potions-grid').data('potionsgridurl'),
				success: function (data) {
					$('#potions-grid').html(data);
					$('.potion').on("click", function() {
						$('#potions-grid').data('Potions').HandlePotionClick($(this).data('id'));
					});
				}
			});
		};

		this.Socket.OnSelected = function(content) {
			let $item = $('#' + content);
			$item.removeClass("green");
			$item.removeClass("blue");
			$item.removeClass("red");
		};

		this.Socket.InitContext();

		// Click handlers
		$('#reset-btn').on("click", function () {
			$.ajax({
				method: "GET",
				url: $(this).data("url")
			});
		});
	});

});
