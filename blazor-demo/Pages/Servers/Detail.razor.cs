using lkcode.hetznercloudapi.Exceptions;
using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace blazor_demo.Pages.Servers;

public partial class Detail
{
    [Parameter]
    public long Id { get; set; }

    [Inject]
    IServerService ServerService { get; set; } = null!;
    [Inject]
    IServerActionsService ServerActionsService { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private bool IsBusy { get; set; } = false;
    private StringBuilder LogStringBuilder { get; set; } = new();
    private Server Server { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        try
        {
            this.Log("GET SERVER BY ID...");
            this.IsBusy = true;

            // load server
            Server server = await this.ServerService.GetByIdAsync(this.Id);

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
            lkcode.hetznercloudapi.Instances.ServerActions.ServerAction result = await this.ServerActionsService.Shutdown(this.Server.Id);

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

    private void Log(string message, bool displayDate = true)
    {
        this.LogStringBuilder.AppendLine($"{((displayDate) ? DateTime.Now.ToLongTimeString() + " - " : "")}{message}");
    }
}
