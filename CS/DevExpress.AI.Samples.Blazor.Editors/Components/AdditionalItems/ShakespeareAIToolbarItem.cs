using DevExpress.AIIntegration;
using DevExpress.AIIntegration.Blazor.HtmlEditor;
using DevExpress.AIIntegration.Extensions;
using Microsoft.AspNetCore.Components;

namespace DevExpress.AI.Samples.Blazor.Editors.Components.AdditionalItems {
    public class ShakespeareAIToolbarItem: BaseAIToolbarItem {
        [Inject] IAIExtensionsContainer? aIExtensionsContainer { get; set; }

        protected override string DefaultItemText => "Rewrite like Shakespeare";

        protected override Task<TextResponse> GetCommandTextResult(string text) {
            var customExtension = aIExtensionsContainer.CreateCustomPromptExtension();
            return customExtension.ExecuteAsync(new CustomPromptRequest("Rewrite the following text in William Shakespeare style.", text));
        }
    }
}