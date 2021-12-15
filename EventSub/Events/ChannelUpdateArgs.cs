using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelUpdate event.
	/// </summary>
	public class ChannelUpdateArgs : EventArgs {
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
		/// Gets the Title.
		/// </summary>
		public string Title { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Language.
		/// </summary>
		public string Language { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Category Id.
		/// </summary>
		public string CategoryId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Category Name.
		/// </summary>
		public string CategoryName { get; set; } = string.Empty;
		/// <summary>
		/// Gets a boolean value indicating if it Is Mature.
		/// </summary>
		public bool IsMature { get; set; }

		/// <summary>
		/// Creates a new default instance of ChannelUpdateArgs.
		/// </summary>
		public ChannelUpdateArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelUpdateArgs with the provided values.
		/// </summary>
		public ChannelUpdateArgs(string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string title, string language, string categoryId, string categoryName, bool isMature) {
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			Title = title;
			Language = language;
			CategoryId = categoryId;
			CategoryName = categoryName;
			IsMature = isMature;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}