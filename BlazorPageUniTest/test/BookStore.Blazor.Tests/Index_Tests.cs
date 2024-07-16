using BookStore.Localization;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Volo.Abp.AspNetCore.Components.Web;
using Xunit;

namespace BookStore.Blazor.Tests;

public class Index_Tests : BookStoreBlazorTestBase
{
    [Fact]
    public void Index_Test()
    {
        // Arrange
        var ctx = CreateTestContext();
        var lh = GetRequiredService<AbpBlazorMessageLocalizerHelper<BookStoreResource>>();
        ctx.Services.AddSingleton(lh);

        // Act
        var cut = ctx.RenderComponent<BookStore.Blazor.Pages.Index>();
        

        // Assert
        cut.Find(".lead").InnerHtml.Contains("Welcome to the application. This is a startup project based on the ABP framework. For more information, visit abp.io.").ShouldBeTrue();
        cut.Find("#username").InnerHtml.Contains("Welcome admin").ShouldBeTrue();
    }
}
