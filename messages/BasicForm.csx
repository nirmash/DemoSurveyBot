#r "System.Runtime"

using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using Microsoft.Bot.Builder.FormFlow.Json;

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    public static IForm<JObject> BuildJsonForm()
    {
        string botMeta = File.ReadAllText(@"d:\home\site\wwwroot\questions.json");
        botMeta = JToken.Parse(botMeta).ToString();
        JObject schema = JObject.Parse(botMeta); 
        return new FormBuilderJson(schema)
            .AddRemainingFields()
            .Build(); 
    }
/*
    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }
*/
    public static IFormDialog<JObject> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildJsonForm, options);
    }
}
