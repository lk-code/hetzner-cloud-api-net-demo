using lkcode.hetznercloudapi.Exceptions;
using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Instances.ServerActions;
using lkcode.hetznercloudapi.Interfaces;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace blazor_demo.Pages.Servers;

public partial class Detail : IDisposable
{
    [Parameter]
    public long Id { get; set; }

    [Inject]
    IServerService ServerService { get; set; } = null!;
    [Inject]
    IServerActionsService ServerActionsService { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
    public Dictionary<string, string> Breadcrumbs = new Dictionary<string, string>()
    {
        { "/", "Übersicht" },
        { "/server", "Server" },
        { "/server/add", "Add Server" },
    };

    private bool IsBusy { get; set; } = false;
    private StringBuilder LogStringBuilder { get; set; } = new();
    private Server Server { get; set; } = null!;

    public void Dispose()
    {
        this._cancellationToken?.Cancel();
        this._cancellationToken?.Dispose();
    }

    private void Log(string message, bool displayDate = true)
    {
        this.LogStringBuilder.AppendLine($"{((displayDate) ? DateTime.Now.ToLongTimeString() + " - " : "")}{message}");
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        try
        {
            this.Log("GET SERVER BY ID...");
            this.IsBusy = true;

            // load server
            Server server = await this.ServerService.GetByIdAsync(this.Id,
                this._cancellationToken.Token);

            this.Server = server;
            this.Log("SUCCESS - Finished");
        }
        catch (ResourceNotFoundException exception)
        {
            // server not found
            this.Log("ERROR - ResourceNotFoundException:");
            this.Log(exception.Message, false);
        }
        catch (Exception exception)
        {
            // display error
            this.Log("ERROR - Exception:");
            this.Log(exception.Message, false);
        }
        finally
        {
            this.IsBusy = false;
        }
    }

    public void OnHomeClick()
    {
        NavigationManager.NavigateTo("/server");
    }

    public async Task OnServerShutdownClick()
    {
        try
        {
            this.Log("SHUTDOWN");
            this.IsBusy = true;

            // load server
            ServerAction result = await this.ServerActionsService.ShutdownAsync(this.Server.Id,
                this._cancellationToken.Token);

            this.Log(JsonConvert.SerializeObject(result), false);
            this.Log("SUCCESS - Finished");
        }
        catch (Exception exception)
        {
            // display error
            this.Log("ERROR - Exception:");
            this.Log(exception.Message, false);
        }
        finally
        {
            this.IsBusy = false;
        }
    }
}