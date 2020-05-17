
namespace PotionCommotion.Models {
	public struct ServerMessage {
		public struct Commands {
			public const string Error = "error";
			public const string Reset = "reset";
			public const string Selected = "selected";
		}

		public string Command;
		public string Content;
		public object Contents;

	}

}
