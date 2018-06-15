using System.Linq;
using ClientDependency.Core;
using Our.Umbraco.InnerContent.PropertyEditors;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;

namespace Our.Umbraco.ContentList.PropertyEditors
{
    [PropertyEditor(PropertyEditorAlias, PropertyEditorName, PropertyEditorViewPath, Group = "rich content", Icon = "icon-page-add", ValueType = "JSON")]
    [PropertyEditorAsset(ClientDependencyType.Javascript, "~/App_Plugins/ContentList/js/contentlist.js")]
    public class ContentListPropertyEditor : SimpleInnerContentPropertyEditor
    {
        public const string PropertyEditorAlias = "Our.Umbraco.ContentList";
        public const string PropertyEditorName = "Content List";
        public const string PropertyEditorViewPath = "/App_Plugins/ContentList/views/contentlist.html";

        public ContentListPropertyEditor()
            : base()
        {
            DefaultPreValues.Add("maxItems", 0);
        }

        protected override PropertyValueEditor CreateValueEditor()
        {
            return new ContentListValueEditor(base.CreateValueEditor());
        }

        internal class ContentListValueEditor : SimpleInnerContentPropertyValueEditor
        {
            public ContentListValueEditor(PropertyValueEditor wrapped) : base(wrapped)
            { }

            public override void ConfigureForDisplay(PreValueCollection preValues)
            {
                base.ConfigureForDisplay(preValues);

                var asDictionary = preValues.PreValuesAsDictionary.ToDictionary(x => x.Key, x => x.Value.Value);
                if (asDictionary.ContainsKey("hideLabel"))
                {
                    var boolAttempt = asDictionary["hideLabel"].TryConvertTo<bool>();
                    if (boolAttempt.Success)
                    {
                        HideLabel = boolAttempt.Result;
                    }
                }
            }
        }

        protected override PreValueEditor CreatePreValueEditor()
        {
            return new ContentListPreValueEditor();
        }

        internal class ContentListPreValueEditor : SimpleInnerContentPreValueEditor
        {
            // MinItems? Let's leave it until someone requests it, (as I don't currently need it)

            [PreValueField("maxItems", "Max Items", "number", Description = "Set the maximum number of items allowed.")]
            public string MaxItems { get; set; }

            [PreValueField("hideLabel", "Hide Label", "boolean", Description = "Set whether to hide the editor label and have the list take up the full width of the editor window.")]
            public string HideLabel { get; set; }
        }
    }
}