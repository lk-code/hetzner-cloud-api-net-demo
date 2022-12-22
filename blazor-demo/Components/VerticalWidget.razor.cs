using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class VerticalWidget
{
    [Parameter]
    public string Link { get; set; } = "";
    [Parameter]
    public string Image { get; set; } = "";
    [Parameter]
    public string Icon { get; set; } = "";
    [Parameter]
    public string Title { get; set; } = "";
    [Parameter]
    public string Label { get; set; } = "";
    [Parameter]
    public string AdditionalInfoLeftIcon { get; set; } = "";
    [Parameter]
    public string AdditionalInfoLeftText { get; set; } = "";
    [Parameter]
    public string AdditionalInfoRightIcon { get; set; } = "";
    [Parameter]
    public string AdditionalInfoRightText { get; set; } = "";
}