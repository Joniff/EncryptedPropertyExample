using ClientDependency.Core;
using System.Collections.Generic;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;

namespace Example
{
	[PropertyEditor(TerrabecEnumerateListsPropertyEditor.PropertyEditorAlias, "Example Property", "/App_Plugins/Example/editor.html?cache=1.0.0", ValueType = PropertyEditorValueTypes.Text, Group = "Examples", Icon = "icon-layers-alt")]
#if DEBUG
	[PropertyEditorAsset(ClientDependencyType.Javascript, "/App_Plugins/Example/Scripts/example.js?cache=1.0.0")]
#else
	[PropertyEditorAsset(ClientDependencyType.Javascript, "/App_Plugins/Example/Scripts/example.min.js?cache=1.0.0")]
#endif
	public class ExamplePropertyEditor : PropertyEditor
	{
		public const string PropertyEditorAlias = nameof(Example) + nameof(ExamplePropertyEditor);

		protected override PreValueEditor CreatePreValueEditor()
		{
			return new ExamplePreValueEditor();
		}

		public ExamplePropertyEditor()
		{
			_defaultPreVals = new Dictionary<string, object>
			{
				{ "definition", "{}" }
			};
		}

		private IDictionary<string, object> _defaultPreVals;
		public override IDictionary<string, object> DefaultPreValues
		{
			get { return _defaultPreVals; }
			set { _defaultPreVals = value; }
		}

		internal class ExamplePreValueEditor : PreValueEditor
		{
			[PreValueField("definition", "Config", "/App_Plugins/Example/Views/config.html?cache=1.0.0", Description = "", HideLabel = true)]
			public PropertyDefinitionModel Definition { get; set; }

		}
	}
}
