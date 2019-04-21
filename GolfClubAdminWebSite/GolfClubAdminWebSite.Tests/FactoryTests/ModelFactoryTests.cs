using System;
using System.Collections.Generic;
using System.Text;

namespace GolfClubAdminWebSite.Tests.FactoryTests
{
    using System.Runtime.InteropServices.ComTypes;
    using Areas.Account.Models;
    using Factories;
    using ManagementAPI.Service.DataTransferObjects;
    using Shouldly;
    using Xunit;

    public class ModelFactoryTests
    {
        [Fact]
        public void ModelFactory_ConvertFrom_RegisterClubAdministratorViewModel_ConvertedSuccessfully()
        {
            ModelFactory factory = new ModelFactory();

            RegisterClubAdministratorViewModel viewModel = new RegisterClubAdministratorViewModel();

            RegisterClubAdministratorRequest request = factory.ConvertFrom(viewModel);

            request.ConfirmPassword.ShouldBe(viewModel.ConfirmPassword);
            request.EmailAddress.ShouldBe(viewModel.Email);
            request.Password.ShouldBe(viewModel.Password);
            request.TelephoneNumber.ShouldBe(viewModel.TelephoneNumber);
        }
    }
}
