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

IChatClient chatClient = new AzureOpenAIClient(
    new Uri(azureOpenAIEndpoint),
    new AzureKeyCredential(azureOpenAIKey)).AsChatClient("gpt4o");

builder.Services.AddDevExpressBlazor();
builder.Services.AddChatClient(config => config.Use(chatClient));
builder.Services.AddDevExpressAI();
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