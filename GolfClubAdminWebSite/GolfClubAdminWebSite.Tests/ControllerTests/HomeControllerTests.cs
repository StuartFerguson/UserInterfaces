using System.Collections.Generic;
using System.Text;

namespace GolfClubAdminWebSite.Tests.ControllerTests
{
    using System.Diagnostics;
    using Controllers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void HomeController_GET_Error_ViewReturned()
        {
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            IActionResult actionResult = controller.Error();

            ViewResult viewResult = Assert.IsType<ViewResult>(actionResult);
            ErrorViewModel model = Assert.IsAssignableFrom<ErrorViewModel>(viewResult.Model);
        }
        
        [Fact]
        public void HomeController_GET_Index_ViewReturned()
        {
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            IActionResult actionResult = controller.Index();

            ViewResult viewResult = Assert.IsType<ViewResult>(actionResult);
        }

        [Fact]
        public void HomeController_GET_Privacy_ViewReturned()
        {
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            IActionResult actionResult = controller.Privacy();

            ViewResult viewResult = Assert.IsType<ViewResult>(actionResult);
        }
    }
}
