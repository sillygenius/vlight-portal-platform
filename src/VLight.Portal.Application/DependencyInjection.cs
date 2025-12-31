// 路径示例：VLight.Portal.Application/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;

namespace VLight.Portal.Application;

public static class DependencyInjection
{
    // 扩展方法：注册应用层服务
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // 注册你的服务（示例）
        // services.AddScoped<IMyService, MyService>();
        return services;
    }
}