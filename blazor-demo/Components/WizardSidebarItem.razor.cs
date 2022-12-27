using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class WizardSidebarItem
{
    [Parameter]
    public string? StepIndex { get; set; } = null;
    [Parameter]
    public string? IconClass { get; set; } = null;
    [Parameter]
    public string Title { get; set; } = "";
    [Parameter]
    public string ContentClass { get; set; } = "";
    [Parameter]
    public EventCallback OnClickCallback { get; set; }
}