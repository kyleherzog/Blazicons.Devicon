# Blazicons.Devicon
Provides the Devicon icon library packaged as [Blazicons](https://github.com/kyleherzog/Blazicons), SVG icon components for Blazor.

Check out the [Demo Site](http://blazicons.com).

![Nuget](https://img.shields.io/nuget/v/Blazicons.Devicon)

[![Build Status](https://dev.azure.com/kyleherzog/Blazicons/_apis/build/status/Blazicons.Devicon?branchName=main)](https://dev.azure.com/kyleherzog/Blazicons/_build/latest?definitionId=17&branchName=main)

## Getting Started
To get started using the Devicon Blazicons, just install the Blazicons.Devicon NuGet package.

Next add the Blazicons reference to the `_Imports.razor` file in the Blazor project.

```csharp
@using Blazicons
```

Finally, add the Blazicon component to your Blazor pages/components.
```html
<Blazicon Svg="DeviconPlain.Blazor"></Blazicon>
<Blazicon Svg="DeviconLine.Blazor"></Blazicon>
<Blazicon Svg="DeviconOriginal.Blazor"></Blazicon>
```

## Parameters & Styling
See the [Blazicons](https://github.com/kyleherzog/Blazicons) documentation for details on parameters and styling.

## Credits
Thanks to the creators of [Devicon](https://github.com/devicons/devicon)