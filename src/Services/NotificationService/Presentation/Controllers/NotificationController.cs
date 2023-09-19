using Microsoft.AspNetCore.Mvc;
using NotificationContract.Models;
using NotificationService.Interfaces;

namespace NotificationService.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;
    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost]
    public async Task<ActionResult> Send(SendNotificationRequest request)
    {
        await _notificationService.SendAsync(request);
        return Ok();
    }

}