<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1251646)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Rich Text Editor and HTML Editor for Blazor - How to integrate AI-powered extensions

This example enables AI-powered extensions for both the DevExpress Blazor Rich Text Editor and HTML Editor. These extensions supply AI functions designed to process text/HTML content.

## Implementation Details

Both the DevExpress Blazor Rich Text Editor ([DxRichEdit](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.DxRichEdit)) and Blazor HTML Editor ([DxHtmlEditor](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxHtmlEditor)) ship with an `AdditionalItems` property. You can populate this property with commands and allow users to process editor text as needs dictate. Available commands for both editors are as follows:

* **Ask AI Assistant** allows user to process text according to a custom prompt.
* **Change Style** rewrite text using a specified style.
* **Change Tone** rewrite text using a specified tone.
* **Expand** expands the text.
* **Explain** explains the text.
* **Proofread** proofreads the text.
* **Shorten** shortens the text.
* **Summarize** summarizes the text.
* **Translate** translates the text into the specified language.

### Register AI Services

Add the following code to the _Program.cs_ file to register AI services in the application:

```cs
using Azure;
using Azure.AI.OpenAI;
using DevExpress.Blazor;
using Microsoft.Extensions.AI;
...
string azureOpenAIEndpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
string azureOpenAIKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressAI((config) => {
    var client = new AzureOpenAIClient(
        new Uri(azureOpenAIEndpoint),
        new AzureKeyCredential(azureOpenAIKey)).AsChatClient("gpt4o");
    config.RegisterChatClient(client);
});
```

### Enable AI-powered extension for the DevExpress Rich Text Editor 

AI-powered extension for Rich Text Editor adds AI-related commands to the editor's context menu. 

Declare DxRichEdit's [AdditionalItems](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.DxRichEdit.AdditionalItems?v=24.2) and populate it with commands in the following manner:

```razor
@using DevExpress.AIIntegration.Blazor.RichEdit
@using DevExpress.Blazor.RichEdit

<DxRichEdit DocumentContent="DocumentContent" CssClass="my-editor">
    <AdditionalItems>
        <ShakespeareAIContextMenuItem />
        <SummarizeAIContextMenuItem />
        <ExplainAIContextMenuItem />
        <ProofreadAIContextMenuItem />
        <ExpandAIContextMenuItem />
        <ShortenAIContextMenuItem />
        <AskAssistantAIContextMenuItem />
        <ChangeStyleAIContextMenuItem />
        <ChangeToneAIContextMenuItem />
        <TranslateAIContextMenuItem Languages="@("German, French, Chinese")" />
    </AdditionalItems>
</DxRichEdit>
```

![](richedit.png)

### Enable AI-powered extension for the DevExpress HTML Editor

The AI-powered extension for our HTML Editor adds AI-related commands to the editor's toolbar.

Declare DxHtmlEditor's [AdditionalItems](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxHtmlEditor.AdditionalItems?v=24.2) and populate it with commands in the following manner:

```razor
@using DevExpress.AI.Samples.Blazor.Editors.Components.AdditionalItems
@using DevExpress.AIIntegration.Blazor.HtmlEditor

<DxHtmlEditor @bind-Markup="Value" CssClass="my-editor" BindMarkupMode="HtmlEditorBindMarkupMode.OnLostFocus">
    <AdditionalItems>
        <ShakespeareAIToolbarItem></ShakespeareAIToolbarItem>
        <SummarizeAIToolbarItem />
        <ExplainAIToolbarItem />
        <ProofreadAIToolbarItem />
        <ExpandAIToolbarItem />
        <ShortenAIToolbarItem />
        <AskAssistantAIToolbarItem />
        <ChangeStyleAIToolbarItem />
        <ChangeToneAIToolbarItem />
        <TranslateAIToolbarItem Languages="@("German, French, Chinese")" />
    </AdditionalItems>
</DxHtmlEditor>
```

![](htmleditor.png)

## Files to Review

* [RichEdit.razor](./CS/DevExpress.AI.Samples.Blazor.Editors/Components/Pages/RichEdit.razor)
* [HtmlEditor.razor](./CS/DevExpress.AI.Samples.Blazor.Editors/Components/Pages/HtmlEditor.razor)
* [Program.cs](./CS/DevExpress.AI.Samples.Blazor.Editors/Program.cs)

## Documentation

*[AI-Powered Extension for Blazor Rich Text Editor](https://docs.devexpress.com/Blazor/405193/components/rich-edit/ai-integration?v=24.2)
*[AI-Powered Extension for Blazor HTML Editor](https://docs.devexpress.com/Blazor/405187/components/html-editor/ai-integration?v=24.2)

## More Examples

* [AI Chat for Blazor - How to add DxAIChat component in Blazor, MAUI, WPF, and WinForms applications](https://github.com/DevExpress-Examples/devexpress-ai-chat-samples)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-ai-integration-to-text-editors&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-ai-integration-to-text-editors&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
