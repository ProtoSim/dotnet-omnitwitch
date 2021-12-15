using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelCheer event.
	/// </summary>
	public class ChannelCheerArgs : EventArgs {
		/// <summary>
		/// Gets a boolean value indicating if it Is Anonymous.
		/// </summary>
		public bool IsAnonymous { get; set; }
		/// <summary>
		/// Gets the User's Id.
		/// </summary>
		public string UserId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the User's Username.
		/// </summary>
		public string UserUsername { get; set; } = string.Empty;
		/// <summary>
		/// Gets the User's Display Name.
		/// </summary>
		public string UserDisplayName { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Broadcaster's User Id.
		/// </summary>
		public string BroadcasterUserId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Broadcaster's Username.
		/// </summary>
		public string BroadcasterUsername { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Broadcaster's Display Name.
		/// </summary>
		public string BroadcasterDisplayName { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Message.
		/// </summary>
		public string Message { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Bits.
		/// </summary>
		public int Bits { get; set; }

		/// <summary>
		/// Creates a new default instance of ChannelCheerArgs.
		/// </summary>
		public ChannelCheerArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelCheerArgs with the provided values.
		/// </summary>
		public ChannelCheerArgs(bool isAnonymous, string userId, string userUsername, string userDisplayName, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string message, int bits) {
			IsAnonymous = isAnonymous;
			UserId = userId;
			UserUsername = userUsername;
			UserDisplayName = userDisplayName;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			Message = message;
			Bits = bits;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}