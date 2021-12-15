using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a ChannelPredictionLock event.
	/// </summary>
	public class ChannelPredictionLockArgs : EventArgs {
		/// <summary>
		/// Gets the Prediction Id.
		/// </summary>
		public string PredictionId { get; set; } = string.Empty;
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
		/// Gets the Outcomes.
		/// </summary>
		public (string Id, string Title, string Color, int Users, int ChannelPoints, List<(string UserId, string UserUsername, string UserDisplayName, int ChannelPointsWon, int ChannelPointsUsed)> TopContributers) Outcomes = (string.Empty, string.Empty, string.Empty, 0, 0, new List<(string UserId, string UserUsername, string UserDisplayName, int ChannelPointsWon, int ChannelPointsUsed)>());
		/// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Locks At.
		/// </summary>
		public string LockedAt { get; set; } = string.Empty;

		/// <summary>
		/// Creates a new default instance of ChannelPredictionLockArgs.
		/// </summary>
		public ChannelPredictionLockArgs() { }

		/// <summary>
		/// Creates a new instance of ChannelPredictionLockArgs with the provided values.
		/// </summary>
		public ChannelPredictionLockArgs(string predictionId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string title, (string Id, string Title, string Color, int Users, int ChannelPoints, List<(string UserId, string UserUsername, string UserDisplayName, int ChannelPointsWon, int ChannelPointsUsed)> TopContributers) outcomes, string startedAt, string lockedAt) {
			PredictionId = predictionId;
			BroadcasterUserId = broadcasterUserId;
			BroadcasterUsername = broadcasterUsername;
			BroadcasterDisplayName = broadcasterDisplayName;
			Title = title;
			Outcomes = outcomes;
			StartedAt = startedAt;
			LockedAt = lockedAt;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}