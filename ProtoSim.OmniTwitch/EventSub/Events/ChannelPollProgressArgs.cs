using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a ChannelPollProgress event.
	/// </summary>
	public class ChannelPollProgressArgs : EventArgs {
        /// <summary>
		/// Gets the Poll Id.
		/// </summary>
		public string PollId { get; set; } = string.Empty;
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
		/// Gets the Choices.
		/// </summary>
		public List<(string Id, string Title, int BitsVotes, int ChannelPointsVotes, int Votes)> Choices = new();
		/// <summary>
		/// Gets the Bits Voting.
		/// </summary>
		public (bool IsEnabled, int AmountPerVote) BitsVoting;
		/// <summary>
		/// Gets the Channel Points Voting.
		/// </summary>
		public (bool IsEnabled, int AmountPerVote) ChannelPointsVoting;
        /// <summary>
		/// Gets the string representation of Started At.
		/// </summary>
		public string StartedAt { get; set; } = string.Empty;
        /// <summary>
		/// Gets the string representation of Ends At.
		/// </summary>
		public string EndsAt { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of ChannelPollProgressArgs.
		/// </summary>
		public ChannelPollProgressArgs() { }

        /// <summary>
		/// Creates a new instance of ChannelPollProgressArgs with the provided values.
		/// </summary>
		public ChannelPollProgressArgs(string pollId, string broadcasterUserId, string broadcasterUsername, string broadcasterDisplayName, string title, List<(string Id, string Title, int BitsVotes, int ChannelPointsVotes, int Votes)> choices, (bool IsEnabled, int AmountPerVote) bitsVoting, (bool IsEnabled, int AmountPerVote) channelPointsVoting, string startedAt, string endsAt) {
            PollId = pollId;
            BroadcasterUserId = broadcasterUserId;
            BroadcasterUsername = broadcasterUsername;
            BroadcasterDisplayName = broadcasterDisplayName;
            Title = title;
            Choices = choices;
            BitsVoting = bitsVoting;
            ChannelPointsVoting = channelPointsVoting;
            StartedAt = startedAt;
            EndsAt = endsAt;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}