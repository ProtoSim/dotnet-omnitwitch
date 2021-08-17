using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelHypeTrainBegin event.
	/// </summary>
	public class ChannelHypeTrainBeginArgs : EventArgs {
        /// <summary>
		/// Gets the Hype Train Id.
		/// </summary>
		public string HypeTrainId { get; set; } = string.Empty;
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
		/// Gets the Points Total.
		/// </summary>
        public int PointsTotal { get; set; }
		/// <summary>
		/// Gets the Points Progress.
		/// </summary>
		public int PointsProgress { get; set; }
		/// <summary>
		/// Gets the Points Goal.
		/// </summary>
		public int PointsGoal { get; set; }
		/// <summary>
		/// Gets the Top Contributions.
		/// </summary>
		public List<(string UserId, string UserUsername, string UserDisplayName, string Type, int Total)> TopContributions = new();
		/// <summary>
		/// Gets the Last Contribution.
		/// </summary>
		public (string UserId, string UserUsername, string UserDisplayName, string Type, int Total) LastContribution = (string.Empty, string.Empty, string.Empty, string.Empty, 0);
        /// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
        /// <summary>
		/// Gets the string representation of Expires At.
		/// </summary>
		public string ExpiresAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelHypeTrainBeginArgs.
		/// </summary>
		public ChannelHypeTrainBeginArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelHypeTrainBeginArgs with the provided values.
		/// </summary>
		public ChannelHypeTrainBeginArgs(string hypeTrainId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, int pointsTotal, int pointsProgress, int pointsGoal, List<(string UserId, string UserUsername, string UserDisplayName, string Type, int Total)> topContributions, (string UserId, string UserUsername, string UserDisplayName, string Type, int Total) lastContribution, string startedAt, string expiresAt) {
            HypeTrainId = hypeTrainId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            PointsTotal = pointsTotal;
            PointsProgress = pointsProgress;
            PointsGoal = pointsGoal;
            TopContributions = topContributions;
            LastContribution = lastContribution;
            StartedAt = startedAt;
            ExpiresAt = expiresAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}