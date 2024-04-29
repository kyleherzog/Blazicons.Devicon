using System.Text.RegularExpressions;
using Blazicons.Generating;
using CodeCasing;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Threading;

namespace Blazicons.Devicon.Generating;

[Generator]
internal class DeviconGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        using var taskContext = new JoinableTaskContext();
        var taskFactory = new JoinableTaskFactory(taskContext);
        var downloader = new RepoDownloader(new Uri(Properties.Resources.DownloadAddress));
        taskFactory.Run(
            async () =>
            {
                await downloader.Download(@"^icons\/.*.svg$").ConfigureAwait(true);
            });

        var svgFolder = Path.Combine(downloader.ExtractedFolder, $"{downloader.RepoName}-{downloader.BranchName}", "icons");
        context.WriteIconsClass("DeviconOriginal", svgFolder, propertyNameFromFileName: GetPropertyName, isFileNameOk: IsOriginalIcon, skipColorScrub: true);
        context.WriteIconsClass("DeviconPlain", svgFolder, propertyNameFromFileName: GetPropertyName, isFileNameOk: IsPlainIcon);
        context.WriteIconsClass("DeviconLine", svgFolder, propertyNameFromFileName: GetPropertyName, isFileNameOk: IsLineIcon);
        downloader.CleanUp();
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        // required by ISourceGenerator
    }

    internal string GetPropertyName(string fileName)
    {
        var result = Path.GetFileNameWithoutExtension(fileName);
        result = Regex.Replace(result, "-(original|plain|line)", string.Empty);
        return result.ToPascalCase();
    }

    internal bool IsLineIcon(string fileName)
    {
        return Regex.IsMatch(fileName, "-line[-.]");
    }

    internal bool IsOriginalIcon(string fileName)
    {
        return Regex.IsMatch(fileName, "-original[-.]");
    }

    internal bool IsPlainIcon(string fileName)
    {
        return Regex.IsMatch(fileName, "-plain[-.]");
    }
}