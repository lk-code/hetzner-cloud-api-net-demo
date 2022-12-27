using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Pages.Servers.AddComponents;

public partial class ServerNetworking
{
    [Parameter]
    public EventCallback OnContinueClicked { get; set; }
    [Parameter]
    public EventCallback OnAbortClicked { get; set; }
    [Parameter]
    public string? ContinueButtonText { get; set; }
    [Parameter]
    public string? AbortButtonText { get; set; }
}