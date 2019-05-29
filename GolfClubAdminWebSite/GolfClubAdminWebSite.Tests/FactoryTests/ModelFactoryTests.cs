using System.Collections.Generic;
using System.Text;

namespace GolfClubAdminWebSite.Tests.FactoryTests
{
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using Factories;
    using ManagementAPI.Service.DataTransferObjects;
    using ManagementAPI.Service.DataTransferObjects.Requests;
    using ManagementAPI.Service.DataTransferObjects.Responses;
    using Shouldly;
    using Xunit;

    public class ModelFactoryTests
    {
        [Fact]
        public void ModelFactory_ConvertFrom_RegisterClubAdministratorViewModel_ConvertedSuccessfully()
        {
            ModelFactory factory = new ModelFactory();

            RegisterClubAdministratorViewModel viewModel = ModelFactoryTestData.GetRegisterClubAdministratorViewModel();

            RegisterClubAdministratorRequest request = factory.ConvertFrom(viewModel);

            request.ConfirmPassword.ShouldBe(viewModel.ConfirmPassword);
            request.EmailAddress.ShouldBe(viewModel.Email);
            request.Password.ShouldBe(viewModel.Password);
            request.TelephoneNumber.ShouldBe(viewModel.TelephoneNumber);
        }

        [Fact]
        public void ModelFactory_ConvertFrom_CreateGolfClubViewModel_ConvertedSuccessfully()
        {
            ModelFactory factory = new ModelFactory();

            CreateGolfClubViewModel viewModel = ModelFactoryTestData.GetCreateGolfClubViewModel();

            CreateGolfClubRequest request = factory.ConvertFrom(viewModel);

            request.AddressLine1.ShouldBe(viewModel.AddressLine1);
            request.Region.ShouldBe(viewModel.Region);
            request.Town.ShouldBe(viewModel.Town);
            request.Website.ShouldBe(viewModel.Website);
            request.Name.ShouldBe(viewModel.Name);
            request.TelephoneNumber.ShouldBe(viewModel.TelephoneNumber);
            request.EmailAddress.ShouldBe(viewModel.EmailAddress);
            request.AddressLine2.ShouldBe(viewModel.AddressLine2);
            request.PostalCode.ShouldBe(viewModel.PostalCode);
            request.TournamentDivisions.ShouldBeEmpty();
        }

        [Fact]
        public void ModelFactory_ConvertFrom_GetGolfClubResponse_ConvertedSuccessfully()
        {
            ModelFactory factory = new ModelFactory();

            GetGolfClubResponse apiResponse = ModelFactoryTestData.GetGetGolfClubResponse();

            UpdateGolfClubViewModel viewModel = factory.ConvertFrom(apiResponse);

            viewModel.AddressLine1.ShouldBe(apiResponse.AddressLine1);
            viewModel.Region.ShouldBe(apiResponse.Region);
            viewModel.Town.ShouldBe(apiResponse.Town);
            viewModel.Website.ShouldBe(apiResponse.Website);
            viewModel.Name.ShouldBe(apiResponse.Name);
            viewModel.TelephoneNumber.ShouldBe(apiResponse.TelephoneNumber);
            viewModel.EmailAddress.ShouldBe(apiResponse.EmailAddress);
            viewModel.AddressLine2.ShouldBe(apiResponse.AddressLine2);
            viewModel.PostalCode.ShouldBe(apiResponse.PostalCode);
            viewModel.Id.ShouldBe(apiResponse.Id);
        }

        [Fact]
        public void ModelFactory_ConvertFrom_MeasuredCourseViewModel_ConvertedSuccessfully()
        {
            ModelFactory factory = new ModelFactory();

            MeasuredCourseViewModel viewModel = ModelFactoryTestData.GetMeasuredCourseViewModel();

            AddMeasuredCourseToClubRequest request = factory.ConvertFrom(viewModel);

            request.Holes.Count.ShouldBe(18);
            request.Name.ShouldBe(viewModel.Name);
            request.StandardScratchScore.ShouldBe(viewModel.StandardScratchScore);
            request.TeeColour.ShouldBe(viewModel.TeeColour);

            request.Holes.Single(x => x.HoleNumber ==1).Par.ShouldBe(viewModel.HoleNumber1Par);
            request.Holes.Single(x => x.HoleNumber == 1).StrokeIndex.ShouldBe(viewModel.HoleNumber1StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 1).LengthInYards.ShouldBe(viewModel.HoleNumber1Yards);

            request.Holes.Single(x => x.HoleNumber == 2).Par.ShouldBe(viewModel.HoleNumber2Par);
            request.Holes.Single(x => x.HoleNumber == 2).StrokeIndex.ShouldBe(viewModel.HoleNumber2StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 2).LengthInYards.ShouldBe(viewModel.HoleNumber2Yards);

            request.Holes.Single(x => x.HoleNumber == 3).Par.ShouldBe(viewModel.HoleNumber3Par);
            request.Holes.Single(x => x.HoleNumber == 3).StrokeIndex.ShouldBe(viewModel.HoleNumber3StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 3).LengthInYards.ShouldBe(viewModel.HoleNumber3Yards);

            request.Holes.Single(x => x.HoleNumber == 4).Par.ShouldBe(viewModel.HoleNumber4Par);
            request.Holes.Single(x => x.HoleNumber == 4).StrokeIndex.ShouldBe(viewModel.HoleNumber4StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 4).LengthInYards.ShouldBe(viewModel.HoleNumber4Yards);

            request.Holes.Single(x => x.HoleNumber == 5).Par.ShouldBe(viewModel.HoleNumber5Par);
            request.Holes.Single(x => x.HoleNumber == 5).StrokeIndex.ShouldBe(viewModel.HoleNumber5StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 5).LengthInYards.ShouldBe(viewModel.HoleNumber5Yards);

            request.Holes.Single(x => x.HoleNumber == 6).Par.ShouldBe(viewModel.HoleNumber6Par);
            request.Holes.Single(x => x.HoleNumber == 6).StrokeIndex.ShouldBe(viewModel.HoleNumber6StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 6).LengthInYards.ShouldBe(viewModel.HoleNumber6Yards);

            request.Holes.Single(x => x.HoleNumber == 7).Par.ShouldBe(viewModel.HoleNumber7Par);
            request.Holes.Single(x => x.HoleNumber == 7).StrokeIndex.ShouldBe(viewModel.HoleNumber7StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 7).LengthInYards.ShouldBe(viewModel.HoleNumber7Yards);

            request.Holes.Single(x => x.HoleNumber == 8).Par.ShouldBe(viewModel.HoleNumber8Par);
            request.Holes.Single(x => x.HoleNumber == 8).StrokeIndex.ShouldBe(viewModel.HoleNumber8StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 8).LengthInYards.ShouldBe(viewModel.HoleNumber8Yards);

            request.Holes.Single(x => x.HoleNumber == 9).Par.ShouldBe(viewModel.HoleNumber9Par);
            request.Holes.Single(x => x.HoleNumber == 9).StrokeIndex.ShouldBe(viewModel.HoleNumber9StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 9).LengthInYards.ShouldBe(viewModel.HoleNumber9Yards);

            request.Holes.Single(x => x.HoleNumber == 10).Par.ShouldBe(viewModel.HoleNumber10Par);
            request.Holes.Single(x => x.HoleNumber == 10).StrokeIndex.ShouldBe(viewModel.HoleNumber10StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 10).LengthInYards.ShouldBe(viewModel.HoleNumber10Yards);

            request.Holes.Single(x => x.HoleNumber == 11).Par.ShouldBe(viewModel.HoleNumber11Par);
            request.Holes.Single(x => x.HoleNumber == 11).StrokeIndex.ShouldBe(viewModel.HoleNumber11StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 11).LengthInYards.ShouldBe(viewModel.HoleNumber11Yards);

            request.Holes.Single(x => x.HoleNumber == 12).Par.ShouldBe(viewModel.HoleNumber12Par);
            request.Holes.Single(x => x.HoleNumber == 12).StrokeIndex.ShouldBe(viewModel.HoleNumber12StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 12).LengthInYards.ShouldBe(viewModel.HoleNumber12Yards);

            request.Holes.Single(x => x.HoleNumber == 13).Par.ShouldBe(viewModel.HoleNumber13Par);
            request.Holes.Single(x => x.HoleNumber == 13).StrokeIndex.ShouldBe(viewModel.HoleNumber13StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 13).LengthInYards.ShouldBe(viewModel.HoleNumber13Yards);

            request.Holes.Single(x => x.HoleNumber == 14).Par.ShouldBe(viewModel.HoleNumber14Par);
            request.Holes.Single(x => x.HoleNumber == 14).StrokeIndex.ShouldBe(viewModel.HoleNumber14StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 14).LengthInYards.ShouldBe(viewModel.HoleNumber14Yards);

            request.Holes.Single(x => x.HoleNumber == 15).Par.ShouldBe(viewModel.HoleNumber15Par);
            request.Holes.Single(x => x.HoleNumber == 15).StrokeIndex.ShouldBe(viewModel.HoleNumber15StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 15).LengthInYards.ShouldBe(viewModel.HoleNumber15Yards);

            request.Holes.Single(x => x.HoleNumber == 16).Par.ShouldBe(viewModel.HoleNumber16Par);
            request.Holes.Single(x => x.HoleNumber == 16).StrokeIndex.ShouldBe(viewModel.HoleNumber16StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 16).LengthInYards.ShouldBe(viewModel.HoleNumber16Yards);

            request.Holes.Single(x => x.HoleNumber == 17).Par.ShouldBe(viewModel.HoleNumber17Par);
            request.Holes.Single(x => x.HoleNumber == 17).StrokeIndex.ShouldBe(viewModel.HoleNumber17StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 17).LengthInYards.ShouldBe(viewModel.HoleNumber17Yards);

            request.Holes.Single(x => x.HoleNumber == 18).Par.ShouldBe(viewModel.HoleNumber18Par);
            request.Holes.Single(x => x.HoleNumber == 18).StrokeIndex.ShouldBe(viewModel.HoleNumber18StrokeIndex);
            request.Holes.Single(x => x.HoleNumber == 18).LengthInYards.ShouldBe(viewModel.HoleNumber18Yards);
        }

        [Fact]
        public void ModelFactory_ConvertFrom_GetMeasuredCourseListResponse_ConvertedSuccessfully()
        {
            ModelFactory factory = new ModelFactory();

            GetMeasuredCourseListResponse apiResponse = ModelFactoryTestData.GetMeasuredCourseListResponse();

            List<MeasuredCourseListViewModel> viewModel = factory.ConvertFrom(apiResponse);

            viewModel.Count.ShouldBe(apiResponse.MeasuredCourses.Count);
            viewModel.First().Id.ShouldBe(apiResponse.MeasuredCourses.First().MeasuredCourseId.ToString());
            viewModel.First().StandardScratchScore.ShouldBe(apiResponse.MeasuredCourses.First().StandardScratchScore);
            viewModel.First().TeeColour.ShouldBe(apiResponse.MeasuredCourses.First().TeeColour);
            viewModel.First().Name.ShouldBe(apiResponse.MeasuredCourses.First().Name);
        }
    }
}
