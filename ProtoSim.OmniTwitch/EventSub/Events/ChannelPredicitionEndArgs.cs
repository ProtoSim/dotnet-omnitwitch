using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelPredicitionEnd event.
	/// </summary>
	public class ChannelPredicitionEndArgs : EventArgs {
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
		/// Gets the WinningOutcome Id.
		/// </summary>
		public string WinningOutcomeId { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Outcomes.
		/// </summary>
		public (string Id, string Title, string Color, int Users, int ChannelPoints, List<(string UserId, string UserUsername, string UserDisplayName, int ChannelPointsWon, int ChannelPointsUsed)> TopContributers) Outcomes = (string.Empty, string.Empty, string.Empty, 0, 0, new List<(string UserId, string UserUsername, string UserDisplayName, int ChannelPointsWon, int ChannelPointsUsed)>());
		/// <summary>
		/// Gets the Status.
		/// </summary>
		public string Status { get; set; } = string.Empty;
        /// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
		/// <summary>
		/// Gets the string representation of Ended At.
		/// </summary>
		public string EndedAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelPredicitionEndArgs.
		/// </summary>
		public ChannelPredicitionEndArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelPredicitionEndArgs with the provided values.
		/// </summary>
		public ChannelPredicitionEndArgs(string predictionId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string title, string winningOutcomeId, (string Id, string Title, string Color, int Users, int ChannelPoints, List<(string UserId, string UserUsername, string UserDisplayName, int ChannelPointsWon, int ChannelPointsUsed)> TopContributers) outcomes, string status, string startedAt, string endedAt) {
            PredictionId = predictionId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Title = title;
            WinningOutcomeId = winningOutcomeId;
            Outcomes = outcomes;
            Status = status;
            StartedAt = startedAt;
            EndedAt = endedAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}