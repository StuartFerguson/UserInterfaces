using System;
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
    }

    public class ModelFactoryTestData
    {
        public static String ConfirmPassword = "123456";
        public static String Password = "123456";
        public static String Email = "testclubadmin@golfclub.co.uk";
        public static String FirstName = "FirstName";
        public static String LastName = "LastName";
        public static String TelephoneNumber = "0123456789";

        public static Guid ClubId = Guid.Parse("E7ED031E-EEAB-4EE6-8D52-A6ACE1F39B88");
        public static String ClubName = "Test Club";
        public static String AddressLine1 = "Address Line 1";
        public static String AddressLine2 = "Address Line 2";
        public static String Region = "Region";
        public static String Website = "www.golfclub.co.uk";
        public static String ClubTelephoneNumber = "0123456789";
        public static String EmailAddress = "testclub@golfclub.co.uk";
        public static String PostalCode = "TE57 1NG";
        public static String Town = "Town";
        
        public static RegisterClubAdministratorViewModel GetRegisterClubAdministratorViewModel()
        {
            return new RegisterClubAdministratorViewModel
                   {
                       ConfirmPassword = ModelFactoryTestData.ConfirmPassword,
                       Email = ModelFactoryTestData.Email,
                       FirstName = ModelFactoryTestData.FirstName,
                       LastName = ModelFactoryTestData.LastName,
                       Password = ModelFactoryTestData.Password,
                       TelephoneNumber = ModelFactoryTestData.TelephoneNumber
                   };
        }

        public static CreateGolfClubViewModel GetCreateGolfClubViewModel()
        {
            return new CreateGolfClubViewModel
                   {
                       Name = ModelFactoryTestData.ClubName,
                       PostalCode = ModelFactoryTestData.PostalCode,
                       TelephoneNumber = ModelFactoryTestData.ClubTelephoneNumber,
                       AddressLine1 = ModelFactoryTestData.AddressLine1,
                       AddressLine2 = ModelFactoryTestData.AddressLine2,
                       EmailAddress = ModelFactoryTestData.EmailAddress,
                       Region = ModelFactoryTestData.Region,
                       Town = ModelFactoryTestData.Town,
                       Website = ModelFactoryTestData.Website
                   };
        }

        public static GetGolfClubResponse GetGetGolfClubResponse()
        {
            return new GetGolfClubResponse
                   {
                       Name = ModelFactoryTestData.ClubName,
                       Town = ModelFactoryTestData.Town,
                       Website = ModelFactoryTestData.Website,
                       Region = ModelFactoryTestData.Region,
                       AddressLine1 = ModelFactoryTestData.AddressLine1,
                       AddressLine2 = ModelFactoryTestData.AddressLine2,
                       EmailAddress = ModelFactoryTestData.EmailAddress,
                       PostalCode = ModelFactoryTestData.PostalCode,
                       TelephoneNumber = ModelFactoryTestData.TelephoneNumber,
                       Id = ModelFactoryTestData.ClubId
                   };
        }

        public static String GolfCourseName = "Test Course";
        public static String GolfCourseTeeColour = "White";
        public static Int32 GolfCourseStandardScratchScore = 70;

        public static Int32 HoleNumber1StrokeIndex = 10;

        public static Int32 HoleNumber1Par = 4;

        public static Int32 HoleNumber1Yards = 348;

        public static Int32 HoleNumber10Par = 4;

        public static Int32 HoleNumber10StrokeIndex = 3;

        public static Int32 HoleNumber10Yards = 399;

        public static Int32 HoleNumber11Par = 4;

        public static Int32 HoleNumber11StrokeIndex = 13;

        public static Int32 HoleNumber11Yards = 401;

        public static Int32 HoleNumber12Par = 4;

        public static Int32 HoleNumber12StrokeIndex = 1;

        public static Int32 HoleNumber12Yards = 401;

        public static Int32 HoleNumber13Par = 5;

        public static Int32 HoleNumber13StrokeIndex = 11;

        public static Int32 HoleNumber13Yards = 530;

        public static Int32 HoleNumber14Par = 3;

        public static Int32 HoleNumber14StrokeIndex = 5;

        public static Int32 HoleNumber14Yards = 196;

        public static Int32 HoleNumber15Par = 4;

        public static Int32 HoleNumber15StrokeIndex = 7;

        public static Int32 HoleNumber15Yards = 355;

        public static Int32 HoleNumber16Par = 4;

        public static Int32 HoleNumber16StrokeIndex = 15;

        public static Int32 HoleNumber16Yards = 243;

        public static Int32 HoleNumber17Par = 4;

        public static Int32 HoleNumber17StrokeIndex = 17;

        public static Int32 HoleNumber17Yards = 286;

        public static Int32 HoleNumber18Par = 4;

        public static Int32 HoleNumber18StrokeIndex = 9;

        public static Int32 HoleNumber18Yards = 399;

        public static Int32 HoleNumber2Par = 4;

        public static Int32 HoleNumber2StrokeIndex = 4;

        public static Int32 HoleNumber2Yards = 402;

        public static Int32 HoleNumber3Par = 3;

        public static Int32 HoleNumber3StrokeIndex = 14;

        public static Int32 HoleNumber3Yards = 207;

        public static Int32 HoleNumber4Par = 4;

        public static Int32 HoleNumber4StrokeIndex = 8;

        public static Int32 HoleNumber4Yards = 405;

        public static Int32 HoleNumber5Par = 4;

        public static Int32 HoleNumber5StrokeIndex = 2;

        public static Int32 HoleNumber5Yards = 428;

        public static Int32 HoleNumber6Par = 5;

        public static Int32 HoleNumber6StrokeIndex = 12;

        public static Int32 HoleNumber6Yards = 477;

        public static Int32 HoleNumber7Par = 3;

        public static Int32 HoleNumber7StrokeIndex = 16;

        public static Int32 HoleNumber7Yards = 186;

        public static Int32 HoleNumber8Par = 4;

        public static Int32 HoleNumber8StrokeIndex = 6;

        public static Int32 HoleNumber8Yards = 397;

        public static Int32 HoleNumber9Par = 3;

        public static Int32 HoleNumber9StrokeIndex = 18;

        public static Int32 HoleNumber9Yards = 130;

        public static MeasuredCourseViewModel GetMeasuredCourseViewModel()
        {
            return new MeasuredCourseViewModel
                   {
                       Name = ModelFactoryTestData.GolfCourseName,
                       StandardScratchScore = ModelFactoryTestData.GolfCourseStandardScratchScore,
                       TeeColour = ModelFactoryTestData.GolfCourseTeeColour,
                       HoleNumber1StrokeIndex = ModelFactoryTestData.HoleNumber1StrokeIndex,
                       HoleNumber2StrokeIndex = ModelFactoryTestData.HoleNumber2StrokeIndex,
                       HoleNumber3StrokeIndex = ModelFactoryTestData.HoleNumber3StrokeIndex,
                       HoleNumber4StrokeIndex = ModelFactoryTestData.HoleNumber4StrokeIndex,
                       HoleNumber5StrokeIndex = ModelFactoryTestData.HoleNumber5StrokeIndex,
                       HoleNumber6StrokeIndex = ModelFactoryTestData.HoleNumber6StrokeIndex,
                       HoleNumber7StrokeIndex = ModelFactoryTestData.HoleNumber7StrokeIndex,
                       HoleNumber8StrokeIndex = ModelFactoryTestData.HoleNumber8StrokeIndex,
                       HoleNumber9StrokeIndex = ModelFactoryTestData.HoleNumber9StrokeIndex,
                       HoleNumber10StrokeIndex = ModelFactoryTestData.HoleNumber10StrokeIndex,
                       HoleNumber11StrokeIndex = ModelFactoryTestData.HoleNumber11StrokeIndex,
                       HoleNumber12StrokeIndex = ModelFactoryTestData.HoleNumber12StrokeIndex,
                       HoleNumber13StrokeIndex = ModelFactoryTestData.HoleNumber13StrokeIndex,
                       HoleNumber14StrokeIndex = ModelFactoryTestData.HoleNumber14StrokeIndex,
                       HoleNumber15StrokeIndex = ModelFactoryTestData.HoleNumber15StrokeIndex,
                       HoleNumber16StrokeIndex = ModelFactoryTestData.HoleNumber16StrokeIndex,
                       HoleNumber17StrokeIndex = ModelFactoryTestData.HoleNumber17StrokeIndex,
                       HoleNumber18StrokeIndex = ModelFactoryTestData.HoleNumber18StrokeIndex,

                       HoleNumber1Yards = ModelFactoryTestData.HoleNumber1Yards,
                       HoleNumber2Yards = ModelFactoryTestData.HoleNumber2Yards,
                       HoleNumber3Yards = ModelFactoryTestData.HoleNumber3Yards,
                       HoleNumber4Yards = ModelFactoryTestData.HoleNumber4Yards,
                       HoleNumber5Yards = ModelFactoryTestData.HoleNumber5Yards,
                       HoleNumber6Yards = ModelFactoryTestData.HoleNumber6Yards,
                       HoleNumber7Yards = ModelFactoryTestData.HoleNumber7Yards,
                       HoleNumber8Yards = ModelFactoryTestData.HoleNumber8Yards,
                       HoleNumber9Yards = ModelFactoryTestData.HoleNumber9Yards,
                       HoleNumber10Yards = ModelFactoryTestData.HoleNumber10Yards,
                       HoleNumber11Yards = ModelFactoryTestData.HoleNumber11Yards,
                       HoleNumber12Yards = ModelFactoryTestData.HoleNumber12Yards,
                       HoleNumber13Yards = ModelFactoryTestData.HoleNumber13Yards,
                       HoleNumber14Yards = ModelFactoryTestData.HoleNumber14Yards,
                       HoleNumber15Yards = ModelFactoryTestData.HoleNumber15Yards,
                       HoleNumber16Yards = ModelFactoryTestData.HoleNumber16Yards,
                       HoleNumber17Yards = ModelFactoryTestData.HoleNumber17Yards,
                       HoleNumber18Yards = ModelFactoryTestData.HoleNumber18Yards,

                       HoleNumber1Par = ModelFactoryTestData.HoleNumber1Par,
                       HoleNumber2Par = ModelFactoryTestData.HoleNumber2Par,
                       HoleNumber3Par = ModelFactoryTestData.HoleNumber3Par,
                       HoleNumber4Par = ModelFactoryTestData.HoleNumber4Par,
                       HoleNumber5Par = ModelFactoryTestData.HoleNumber5Par,
                       HoleNumber6Par = ModelFactoryTestData.HoleNumber6Par,
                       HoleNumber7Par = ModelFactoryTestData.HoleNumber7Par,
                       HoleNumber8Par = ModelFactoryTestData.HoleNumber8Par,
                       HoleNumber9Par = ModelFactoryTestData.HoleNumber9Par,
                       HoleNumber10Par = ModelFactoryTestData.HoleNumber10Par,
                       HoleNumber11Par = ModelFactoryTestData.HoleNumber11Par,
                       HoleNumber12Par = ModelFactoryTestData.HoleNumber12Par,
                       HoleNumber13Par = ModelFactoryTestData.HoleNumber13Par,
                       HoleNumber14Par = ModelFactoryTestData.HoleNumber14Par,
                       HoleNumber15Par = ModelFactoryTestData.HoleNumber15Par,
                       HoleNumber16Par = ModelFactoryTestData.HoleNumber16Par,
                       HoleNumber17Par = ModelFactoryTestData.HoleNumber17Par,
                       HoleNumber18Par = ModelFactoryTestData.HoleNumber18Par
                   };
        }
    }
}
