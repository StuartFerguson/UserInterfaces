namespace GolfClubAdminWebSite.Tests.ControllerTests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Areas.Account.Controllers;
    using Areas.Account.Models;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Services;
    using Shouldly;
    using Xunit;

    public class RegistrationControllerTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("returnurl")]
        public async Task RegistrationController_GET_Register_ViewReturned(String returnUrl)
        {
            Mock<IClient> client = new Mock<IClient>();
            RegistrationController controller = new RegistrationController(client.Object);

            IActionResult actionResult = await controller.Register(CancellationToken.None, returnUrl);

            ViewResult viewResult = actionResult.ShouldBeOfType<ViewResult>();
            viewResult.ViewData.Count.ShouldBe(1);
            viewResult.ViewData["ReturnUrl"].ShouldBe(returnUrl);
        }

        [Fact]
        public async Task RegistrationController_POST_Register_LoginScreenShown()
        {
            RegisterClubAdministratorViewModel viewModel = new RegisterClubAdministratorViewModel();

            Mock<IClient> client = new Mock<IClient>();
            RegistrationController controller = new RegistrationController(client.Object);

            IActionResult result = await controller.Register(viewModel, CancellationToken.None);

            RedirectToActionResult redirect = result.ShouldBeOfType<RedirectToActionResult>();
            redirect.ActionName.ShouldBe("Registered");           
        }

        [Fact]
        public async Task RegistrationController_POST_Register_ErrorsDisplayed()
        {
            RegisterClubAdministratorViewModel viewModel = new RegisterClubAdministratorViewModel();

            Mock<IClient> client = new Mock<IClient>();
            RegistrationController controller = new RegistrationController(client.Object);

            controller.ModelState.AddModelError("FirstName", "Required");

            IActionResult result = await controller.Register(viewModel, CancellationToken.None);

            ViewResult viewResult = result.ShouldBeOfType<ViewResult>();
            viewResult.ViewData.ModelState.IsValid.ShouldBeFalse();
            viewResult.ViewData.ModelState.ErrorCount.ShouldBe(1);
        }

        [Fact]
        public async Task RegistrationController_GET_Registered_ViewReturned()
        {
            Mock<IClient> client = new Mock<IClient>();
            RegistrationController controller = new RegistrationController(client.Object);

            IActionResult actionResult = await controller.Registered(CancellationToken.None);

            ViewResult viewResult = actionResult.ShouldBeOfType<ViewResult>();
        }
    }
}