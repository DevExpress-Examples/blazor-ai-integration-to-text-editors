<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1251646)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Rich Text Editor and HTML Editor for Blazor - How to integrate AI-powered extensions

This example integrates AI-powered extensions in Rich Text Editor and HTML Editor. These extensions add UI elements to an editor and allows users to process editor content with AI functions.

## Implementation Details

[DxRichEdit](https://docs.devexpress.com/Blazor/DevExpress.Blazor.RichEdit.DxRichEdit) and [DxHtmlEditor](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxHtmlEditor) components implement the `AdditionalSettings` property. You can populate this property with commands that allow users to process editor text. Available commands for both editors are the following:

* `CustomAISettings` allows user to ask a custom question to editor content.
* `ExpandAISettings` makes the text longer.
* `ExplainAISettings` explains the text.
* `ProofreadAISettings` proofreads the text.
* `RewriteAISettings` rewrites the text in the specified style.
* `ShortenAISettings` makes the text shorter.
* `SummaryAISettings` creates text summary.
* `ToneAISettings` - rewrites the text in the specified tone.
* `TranslateAISettings` translates text into the specified language.

### Register AI Services

Add the following code to the _Program.cs_ file to register AI services in the application:

```cs
using DevExpress.AIIntegration;

string azureOpenAIEndpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
string azureOpenAIKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");
...
builder.Services.AddDevExpressAI((config) => {
    var client = new AzureOpenAIClient(
        new Uri(azureOpenAIEndpoint),
        new AzureKeyCredential(azureOpenAIKey));
    config.RegisterChatClientOpenAIService(client, "gpt4o");
    config.RegisterOpenAIAssistants(client, "gpt4o");
});
```

### AI-powered extension for Rich Text Editor 

AI-powered extension for Rich Text Editor adds AI-related commands in the editor's context menu. 

Declare DxRichEdit's `AdditionalSettings` and populate it with commands in the following manner:

```razor
@using DevExpress.AIIntegration.Blazor.RichEdit
@using DevExpress.Blazor.RichEdit

<DxRichEdit DocumentContent="DocumentContent" CssClass="my-editor">
    <AdditionalSettings>
        <SummaryAISettings />
        <ExplainAISettings />
        <ProofreadAISettings />
        <ExpandAISettings />
        <ShortenAISettings />
        <CustomAISettings />
        <RewriteAISettings />
        <ToneAISettings />
        <TranslateAISettings Languages="@("German, French, Chinese")" />
    </AdditionalSettings>
</DxRichEdit>
```

![](richedit.png)

### AI-powered extension for HTML Editor

AI-powered extension for HTML Editor adds AI-related commands in the editor's toolbar. 

Declare DxHtmlEditor's `AdditionalSettings` and populate it with commands in the following manner:

```razor
@using DevExpress.AIIntegration.Blazor.HtmlEditor

<DxHtmlEditor @bind-Markup="Value" CssClass="my-editor" BindMarkupMode="HtmlEditorBindMarkupMode.OnLostFocus">
    <AdditionalSettings>
        <SummaryAISettings />
        <ExplainAISettings />
        <ProofreadAISettings />
        <ExpandAISettings />
        <ShortenAISettings />
        <CustomAISettings />
        <RewriteAISettings />
        <ToneAISettings />
        <TranslateAISettings Languages="@("German, French, Chinese")" />
    </AdditionalSettings>
</DxHtmlEditor>
```

![](htmleditor.png)

## Files to Review

* [RichEdit.razor](./CS/DevExpress.AI.Samples.Blazor.Editors/Components/Pages/RichEdit.razor)
* [HtmlEditor.razor](./CS/DevExpress.AI.Samples.Blazor.Editors/Components/Pages/HtmlEditor.razor)
* [Program.cs](./CS/DevExpress.AI.Samples.Blazor.Editors/Program.cs)

<!-- add later
## Documentation

- link
- link
-->

## More Examples

* [AI Chat for Blazor - How to add DxAIChat component in Blazor, MAUI, WPF, and WinForms applications](https://github.com/DevExpress-Examples/devexpress-ai-chat-samples)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-ai-integration-to-text-editors&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-ai-integration-to-text-editors&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
