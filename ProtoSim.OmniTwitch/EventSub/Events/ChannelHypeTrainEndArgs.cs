using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelHypeTrainEnd event.
	/// </summary>
	public class ChannelHypeTrainEndArgs : EventArgs {
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
		/// Gets the Level.
		/// </summary>
		public int Level { get; set; }
		/// <summary>
		/// Gets the Points Total.
		/// </summary>
		public int PointsTotal { get; set; }
		/// <summary>
		/// Gets the Top Contributions.
		/// </summary>
		public List<(string UserId, string UserUsername, string UserDisplayName, string Type, int Total)> TopContributions = new();
        /// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Ended At.
		/// </summary>
		public string EndedAt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Cooldown Ends At.
		/// </summary>
		public string CooldownEndsAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelHypeTrainEndArgs.
		/// </summary>
		public ChannelHypeTrainEndArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelHypeTrainEndArgs with the provided values.
		/// </summary>
		public ChannelHypeTrainEndArgs(string hypeTrainId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, int level, int pointsTotal, List<(string UserId, string UserUsername, string UserDisplayName, string Type, int Total)> topContributions, string startedAt, string endedAt, string cooldownEndsAt) {
            HypeTrainId = hypeTrainId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Level = level;
            PointsTotal = pointsTotal;
            TopContributions = topContributions;
            StartedAt = startedAt;
            EndedAt = endedAt;
            CooldownEndsAt = cooldownEndsAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}