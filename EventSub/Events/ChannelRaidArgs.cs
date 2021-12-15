using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelRaid event.
	/// </summary>
	public class ChannelRaidArgs : EventArgs {
		/// <summary>
		/// Gets the From Broadcaster's User Id.
		/// </summary>
		public string FromBroadcasterUserId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the From Broadcaster's Username.
		/// </summary>
		public string FromBroadcasterUsername { get; set; } = string.Empty;
		/// <summary>
		/// Gets the From Broadcaster's Display Name.
		/// </summary>
		public string FromBroadcasterDisplayName { get; set; } = string.Empty;
		/// <summary>
		/// Gets the To Broadcaster's User Id.
		/// </summary>
		public string ToBroadcasterUserId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the To Broadcaster's Username.
		/// </summary>
		public string ToBroadcasterUsername { get; set; } = string.Empty;
		/// <summary>
		/// Gets the To Broadcaster's Display Name.
		/// </summary>
		public string ToBroadcasterDisplayName { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Viewers.
		/// </summary>
		public int Viewers { get; set; }

		/// <summary>
		/// Creates a new default instance of ChannelRaidArgs.
		/// </summary>
		public ChannelRaidArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelRaidArgs with the provided values.
		/// </summary>
		public ChannelRaidArgs(string fromBroadcasterUserId, string fromBroadcasterUsername, string fromBroadcasterDisplayName, string toBroadcasterUserId, string toBroadcasterUsername, string toBroadcasterDisplayName, int viewers) {
			FromBroadcasterUserId = fromBroadcasterUserId;
			FromBroadcasterUsername = fromBroadcasterUsername;
			FromBroadcasterDisplayName = fromBroadcasterDisplayName;
			ToBroadcasterUserId = toBroadcasterUserId;
			ToBroadcasterUsername = toBroadcasterUsername;
			ToBroadcasterDisplayName = toBroadcasterDisplayName;
			Viewers = viewers;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}