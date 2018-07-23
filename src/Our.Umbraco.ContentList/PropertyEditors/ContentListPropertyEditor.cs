using ClientDependency.Core;
using Our.Umbraco.InnerContent.PropertyEditors;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;

namespace Our.Umbraco.ContentList.PropertyEditors
{
    [PropertyEditor(PropertyEditorAlias, PropertyEditorName, PropertyEditorValueTypes.Json, PropertyEditorViewPath, Group = "rich content", Icon = "icon-page-add")]
    [PropertyEditorAsset(ClientDependencyType.Javascript, "~/App_Plugins/ContentList/contentlist.js")]
    public class ContentListPropertyEditor : SimpleInnerContentPropertyEditor
    {
        public const string PropertyEditorAlias = "Our.Umbraco.ContentList";
        public const string PropertyEditorName = "Content List";
        public const string PropertyEditorViewPath = "~/App_Plugins/ContentList/contentlist.html";

        public ContentListPropertyEditor()
            : base()
        {
            DefaultPreValues.Add("maxItems", 0);
            DefaultPreValues.Add("hideLabel", "0");
        }

        protected override PropertyValueEditor CreateValueEditor()
        {
            return new SimpleInnerContentPropertyValueEditor(base.CreateValueEditor());
        }

        protected override PreValueEditor CreatePreValueEditor()
        {
            return new ContentListPreValueEditor();
        }

        internal class ContentListPreValueEditor : SimpleInnerContentPreValueEditor
        {
            public ContentListPreValueEditor()
                : base()
            {
                // TODO: Once InnerContent exposes these extension methods, (in v2.0.1), uncomment the following lines. [LK:2018-07-20]
                ////Fields.Add("maxItems", "Max Items", "number", "Set the maximum number of items allowed.");
                ////Fields.AddHideLabel();

                Fields.AddRange(new[]
                {
                    new PreValueField
                    {
                        Key = "maxItems",
                        Name = "Max Items",
                        View = "number",
                        Description = "Set the maximum number of items allowed."
                    },
                    new PreValueField
                    {
                        Key = "hideLabel",
                        Name = "Hide Label",
                        View = "boolean",
                        Description = "Set whether to hide the editor label and have the list take up the full width of the editor window."
                    }
                });
            }
        }
    }
}