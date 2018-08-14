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
                Fields.Add("maxItems", "Max Items", "number", "Set the maximum number of items allowed.");
                Fields.AddHideLabel();
            }
        }
    }
}