﻿using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using lkcode.hetznercloudapi.ParameterObjects.Sort;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting.Server;

namespace blazor_demo.Pages.Servers;

public partial class Index
{
    [Inject]
    IServerService ServerService { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private List<Server> _servers = new List<Server>();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var servers = await this.ServerService.GetAllAsync(
            1,
            25,
            new List<IFilter>
            {
                //new NameFilter("lk")
            },
            new Sorting<ServerSortField>(ServerSortField.Name, SortingDirection.DESC));

        _servers = servers.Items.ToList();
    }

    public void OnServerClick(Server server)
    {
        this.NavigationManager.NavigateTo($"/server/{server.Id}");
    }

    public void OnAddServerClick()
    {
        this.NavigationManager.NavigateTo($"/server/add");
    }
}