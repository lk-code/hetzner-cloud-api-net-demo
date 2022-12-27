using System;
using System.Globalization;
using System.Text;
using blazor_demo.Pages.Servers.AddComponents;
using lkcode.hetznercloudapi.Exceptions;
using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Pages.Servers;

public partial class Add : IDisposable
{
    [Inject]
    IServerService ServerService { get; set; } = null!;

    private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
    public Dictionary<string, string> Breadcrumbs = new Dictionary<string, string>()
    {
        { "/", "Overview" },
        { "/server", "Server" },
        { "/server/add", "New Server" },
    };

    private bool IsBusy { get; set; } = false;
    private StringBuilder LogStringBuilder { get; set; } = new();
    private List<(string Name, string Key, string Icon, bool IsFinished)> _steps = new List<(string Name, string Key, string Icon, bool IsFinished)>
    {
        { ("Location", "location", "si si-pointer", false) },
        { ("OS Image", "os-image", "si si-disc", false) },
        { ("Server Type", "type", "si si-speedometer", false) },
        { ("Networking", "networking", "si si-globe", false) },
        { ("SSH", "ssh", "fa fa-terminal", false) },
        { ("Volumes", "volumes", "si si-layers", false) },
        { ("Firewalls", "firewalls", "si si-shield", false) },
        { ("Backups", "backups", "si si-cloud-upload", false) },
        { ("Placement Groups", "placement-groups", "si si-notebook", false) },
        { ("Labels", "labels", "si si-list", false) },
        { ("Cloud Config", "cloud-config", "si si-equalizer", false) },
        { ("Name", "name", "si si-tag", false) }
    };
    private List<string> _finishedSteps = new List<string>();
    private string _currentStep = "";
    private ServerLocation? ServerLocationElement = null;

    public void Dispose()
    {
        this._cancellationToken?.Cancel();
        this._cancellationToken?.Dispose();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        this.GoToStep(0);
    }

    private void LastStepClicked()
    {
        this._finishedSteps.Remove(this._currentStep);

        int currentIndex = this._steps.FindIndex(x => x.Key == this._currentStep);

        this.GoToStep(currentIndex - 1);
    }

    private void NextStepClicked()
    {
        this._finishedSteps.Add(this._currentStep);

        int currentIndex = this._steps.FindIndex(x => x.Key == this._currentStep);

        this.GoToStep(currentIndex + 1);
    }

    private void GoToStep(int stepIndex)
    {
        if (stepIndex < 0
            || this._steps.Count() < stepIndex)
        {
            return;
        }

        this._currentStep = this._steps[stepIndex].Key;
    }

    private void Log(string message, bool displayDate = true)
    {
        this.LogStringBuilder.AppendLine($"{((displayDate) ? DateTime.Now.ToLongTimeString() + " - " : "")}{message}");
    }

    public async Task OnCreateServerClicked()
    {
        // save server
        string name = "";
        string image = "";
        string serverType = "";
        string? datacenter = null;
        string? location = null;
        bool? startAfterCreate = null;
        object? labels = null;
        bool? automount = null;
        IEnumerable<long>? volumes = null;
        IEnumerable<string>? sshKeys = null;
        IEnumerable<long>? networks = null;
        object? publicNet = null;
        IEnumerable<long>? firewalls = null;
        long? placementGroup = null;
        string? userData = null;

        await this.ServerService.CreateAsync(name,
            image,
            serverType,
            datacenter,
            location,
            startAfterCreate,
            labels,
            automount,
            volumes,
            sshKeys,
            networks,
            publicNet,
            firewalls,
            placementGroup,
            userData,
            this._cancellationToken.Token);
    }
}