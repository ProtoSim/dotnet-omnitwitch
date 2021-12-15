using Newtonsoft.Json;

namespace ProtoSim.OmniTwitch.EventSub.Events {
	/// <summary>
	/// Provides a set of parameters related to a DropEntitlementGrant event.
	/// </summary>
	public class DropEntitlementGrantArgs : EventArgs {
		/// <summary>
		/// Gets the Id.
		/// </summary>
		public string Id { get; set; } = string.Empty;
		/// <summary>
		/// Gets the Data.
		/// </summary>
		public List<(string OrganizationId, string CategoryId, string CategoryName, string CampaignId, string UserId, string UserDisplayName, string UserUsername, string EntitlementId, string BenefitId, string CreatedAt)> Data = new();

		/// <summary>
		/// Creates a new default instance of DropEntitlementGrantArgs.
		/// </summary>
		public DropEntitlementGrantArgs() { }

		/// <summary>
		/// Creates a new instance of DropEntitlementGrantArgs with the provided values.
		/// </summary>
		public DropEntitlementGrantArgs(string id, List<(string OrganizationId, string CategoryId, string CategoryName, string CampaignId, string UserId, string UserDisplayName, string UserUsername, string EntitlementId, string BenefitId, string CreatedAt)> data) {
			Id = id;
			Data = data;
		}

		/// <summary>
		/// Converts the object to a JSON string.
		/// </summary>
		public override string ToString() => JsonConvert.SerializeObject(this);
	}
}