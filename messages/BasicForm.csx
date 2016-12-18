#r "System.Runtime"
#r "Newtonsoft.Json"

using System;
using System.IO;
using Microsoft.Bot.Builder.FormFlow;
using Newtonsoft.Json;

public enum CarOptions { Convertible = 1, SUV, EV };
public enum ColorOptions { Red = 1, White, Blue };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("Hello! What is your {&}?")]
    public string Name { get; set; }

    [Prompt("Please select your favorite car type {||}")]
    public CarOptions Car { get; set; }

    [Prompt("Please select your favorite {&} {||}")]
    public ColorOptions Color { get; set; }

    public static IForm<JObject> BuildJsonForm()
    {
        string botMeta = File.ReadAllText(@"d:\home\site\wwwroot\questions.json");
        botMeta = JToken.Parse(botMeta).ToString();
        var schema = JObject.Parse(botMeta);
        return new FormBuilderJson(schema)
            .AddRemainingFields()
            .Build();
    }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildJsonForm, options);
    }
}
