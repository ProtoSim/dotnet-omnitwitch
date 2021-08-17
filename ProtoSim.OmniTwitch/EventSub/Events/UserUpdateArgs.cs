using System;
using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
    /// <summary>
	/// Provides a set of parameters related to a UserUpdate event.
	/// </summary>
	public class UserUpdateArgs : EventArgs {
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
		/// Gets the Email.
		/// </summary>
		public string Email { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Description.
		/// </summary>
		public string Description { get; set; } = string.Empty;

        /// <summary>
		/// Creates a new default instance of UserUpdateArgs.
		/// </summary>
		public UserUpdateArgs() { }

        /// <summary>
		/// Creates a new instance of UserUpdateArgs with the provided values.
		/// </summary>
		public UserUpdateArgs(string userId, string userUsername, string userDisplayName, string email, string description) {
            UserId = userId;
            UserUsername = userUsername;
            UserDisplayName = userDisplayName;
            Email = email;
            Description = description;
        }

        /// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
    }
}