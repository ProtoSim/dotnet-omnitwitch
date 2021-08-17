using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelSubscriptionMessage event.
	/// </summary>
	public class ChannelSubscriptionMessageArgs : EventArgs {
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
		/// Gets the Tier.
		/// </summary>
		public string Tier { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Message.
		/// </summary>
		public (string Text, List<(int Begin, int End, string Id)> Emotes) Message = (string.Empty, new List<(int Begin, int End, string Id)>());
		/// <summary>
		/// Gets the Cumulative Total.
		/// </summary>
		public int CumulativeTotal { get; set; }
		/// <summary>
		/// Gets the Streak Months.
		/// </summary>
		public int StreakMonths { get; set; }
		/// <summary>
		/// Gets the Duration Months.
		/// </summary>
		public int DurationMonths { get; set; }

        /// <summary>
		/// Creates a new default instance of ChannelSubscriptionMessageArgs.
		/// </summary>
		public ChannelSubscriptionMessageArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelSubscriptionMessageArgs with the provided values.
		/// </summary>
		public ChannelSubscriptionMessageArgs(string userId, string userUsername, string userDisplayName, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string tier, (string Text, List<(int Begin, int End, string Id)> Emotes) message, int cumulativeTotal, int streakMonths, int durationMonths) {
            UserId = userId;
            UserUsername = userUsername;
            UserDisplayName = userDisplayName;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Tier = tier;
            Message = message;
            CumulativeTotal = cumulativeTotal;
            StreakMonths = streakMonths;
            DurationMonths = durationMonths;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}