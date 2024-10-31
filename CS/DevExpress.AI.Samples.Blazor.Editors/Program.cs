using Azure;
using Azure.AI.OpenAI;
using DevExpress.AI.Samples.Blazor.Editors.Components;
using DevExpress.Blazor;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string azureOpenAIEndpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
string azureOpenAIKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressAI((config) => {
    var client = new AzureOpenAIClient(
        new Uri(azureOpenAIEndpoint),
        new AzureKeyCredential(azureOpenAIKey)).AsChatClient("gpt4o");
    config.RegisterChatClient(client);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();