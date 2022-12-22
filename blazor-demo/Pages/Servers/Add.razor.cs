using System;
using System.Text;
using lkcode.hetznercloudapi.Exceptions;
using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Pages.Servers;

public partial class Add
{
    [Inject]
    IServerService ServerService { get; set; } = null!;

    private bool IsBusy { get; set; } = false;
    private StringBuilder LogStringBuilder { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    public async Task OnCreateServerClick()
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

        await this.ServerService.Create(name,
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
            CancellationToken.None);
    }

    private void Log(string message, bool displayDate = true)
    {
        this.LogStringBuilder.AppendLine($"{((displayDate) ? DateTime.Now.ToLongTimeString() + " - " : "")}{message}");
    }
}