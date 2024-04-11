using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace RoslynAnalysis
{
    class Program
    {
        static async Task Main()
        {
            using var workspace = MSBuildWorkspace.Create();
            workspace.WorkspaceFailed += (sender, e) => Console.WriteLine($"FAILED: {e.Diagnostic}");

            var projectPath = Path.GetFullPath("RoslynAnalysis.csproj");

            Console.WriteLine("Start reading project file...");
            var project = await workspace.OpenProjectAsync(projectPath);
            var compilation = project.GetCompilationAsync();

            Console.WriteLine("Sucessfully completed.");
        }
    }

    public class DummyClass
    {
        public string DummyProp { get; set; }
    }
}
