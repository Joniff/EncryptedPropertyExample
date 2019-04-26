using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Example
{
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(PropertyModelJsonConvertor))]
	[DebuggerDisplay("{connector")]
	public class PropertyModel
	{
		private static Cryptography cryptography = new Cryptography(nameof(Example));

		[JsonProperty(PropertyName = "connector")]

		private string connector;
		public string Connector 
		{ 
			get
			{
				return connector;
			}
			set
			{
				connector = value;
			}
		}
		
		public PropertyModel()
		{
		}

		public PropertyModel(PropertyModel other)
		{
			Connector = other.Connector;
		}

		public PropertyModel(string json) : this(string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject<PropertyModel>(json[0] == '{' ? json : cryptography.Decrypt(json)))
		{ 
		}

		public PropertyModel(JObject data) : this(data.ToObject<PropertyModel>())
		{
		}

		public override string ToString()                                                                                                                                        
		{
			return cryptography.Encrypt(JsonConvert.SerializeObject(this));
		}

		public static implicit operator string(PropertyModel model)
		{
			return cryptography.Encrypt(JsonConvert.SerializeObject(model));
		}

		public static implicit operator PropertyModel(string text)
		{
			return string.IsNullOrWhiteSpace(text) ? new PropertyModel() : new PropertyModel(text[0] == '{' ? text : cryptography.Decrypt(text));
		}
	}
}
