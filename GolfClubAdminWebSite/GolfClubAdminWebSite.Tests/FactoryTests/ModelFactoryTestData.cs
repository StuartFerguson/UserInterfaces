namespace GolfClubAdminWebSite.Tests.FactoryTests
{
    using System;
    using System.Collections.Generic;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using Areas.MatchSecretary.Models;
    using ManagementAPI.Service.DataTransferObjects.Requests;
    using ManagementAPI.Service.DataTransferObjects.Responses;

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

        public static Guid GolfCourseId = Guid.Parse("4CA78A99-1867-472D-9BEA-E6ABF96054E1");
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

        private static String UserType = "Match Secretary";

        private static Guid GolfClubId = Guid.Parse("D79D7371-EB8C-4362-9F9D-596C63AE2FB4");

        private static Guid UserId = Guid.Parse("2085948A-92BE-4FAF-B0F2-DF7D7B78775E");

        private static Int32 TournamentFormat = 1;

        private static Int32 MemberCategory = 1;

        private static Guid MeasuredCourseId = Guid.Parse("6AA71105-5A4E-48C7-96A6-1ED0CF93579A");

        private static DateTime? TournamentDate = new DateTime(2019,7,23);

        private static String TournamentName = "Test Tournament";

        private static Boolean TournamentHasBeenCancelled = false;

        private static Boolean TournamentHasBeenCompleted = true;

        private static Boolean HasResultBeenProduced = true;

        private static String MeasuredCourseName = "Measured Course 1";

        private static Int32 MeasuredCourseSSS = 70;

        private static String MeasuredCourseTeeColour = "White";

        private static PlayerCategory PlayerCategory = PlayerCategory.Gents;

        private static Int32 PlayersScoresRecordedCount = 25;

        private static Int32 PlayersSignedUpCount = 25;

        private static Guid TournamentId = Guid.Parse("59C2F76A-0080-42D7-B32E-99832B4E696A");

        public static GetNumberOfMembersByHandicapCategoryReportResponse GetNumberOfMembersByHandicapCategoryReportResponse()
        {
            return new GetNumberOfMembersByHandicapCategoryReportResponse
                   {
                       GolfClubId = ModelFactoryTestData.GolfClubId,
                       MembersByHandicapCategoryResponse = new List<MembersByHandicapCategoryResponse>
                                                           {
                                                               new MembersByHandicapCategoryResponse
                                                               {
                                                                   HandicapCategory = 1,
                                                                   NumberOfMembers = 15
                                                               },
                                                               new MembersByHandicapCategoryResponse
                                                               {
                                                                   HandicapCategory = 2,
                                                                   NumberOfMembers = 25
                                                               }
                                                           }
                   };
        }

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

        public static GetMeasuredCourseListResponse GetMeasuredCourseListResponse()
        {
            return new GetMeasuredCourseListResponse
                   {
                       GolfClubId = ModelFactoryTestData.ClubId,
                       MeasuredCourses = new List<MeasuredCourseListResponse>
                                         {
                                             new MeasuredCourseListResponse
                                             {
                                                 TeeColour = ModelFactoryTestData.GolfCourseTeeColour,
                                                 Name = ModelFactoryTestData.GolfCourseName,
                                                 StandardScratchScore = ModelFactoryTestData.GolfCourseStandardScratchScore,
                                                 MeasuredCourseId = ModelFactoryTestData.GolfCourseId
                                             }
                                         }
                   };
        }

        public static GetGolfClubUserListResponse GetGolfClubUserListResponse()
        {
            return new GetGolfClubUserListResponse
                   {
                       Users = new List<GolfClubUserResponse>
                               {
                                   new GolfClubUserResponse
                                   {
                                       GivenName = ModelFactoryTestData.FirstName,
                                       FamilyName = ModelFactoryTestData.LastName,
                                       MiddleName = String.Empty,
                                       Email = ModelFactoryTestData.Email,
                                       UserType = ModelFactoryTestData.UserType,
                                       PhoneNumber = ModelFactoryTestData.TelephoneNumber,
                                       UserName = ModelFactoryTestData.Email,
                                       GolfClubId = ModelFactoryTestData.GolfClubId,
                                       UserId = ModelFactoryTestData.UserId
                                   }
                               }
                   };
        }

        public static CreateGolfClubUserViewModel GetCreateGolfClubUserViewModel()
        {
            return new CreateGolfClubUserViewModel
                   {
                       FamilyName = ModelFactoryTestData.LastName,
                       MiddleName = String.Empty,
                       GivenName = ModelFactoryTestData.FirstName,
                       Email = ModelFactoryTestData.Email,
                       TelephoneNumber = ModelFactoryTestData.TelephoneNumber
                   };
        }

        public static CreateTournamentViewModel GetCreateTournamentViewModel()
        {
            return new CreateTournamentViewModel()
            {
                Format = ModelFactoryTestData.TournamentFormat,
                MemberCategory = ModelFactoryTestData.MemberCategory,
                MeasuredCourseId = ModelFactoryTestData.MeasuredCourseId,
                TournamentDate = ModelFactoryTestData.TournamentDate,
                Name = ModelFactoryTestData.TournamentName
            };
        }

        public static GetTournamentListResponse GetTournamentListResponse()
        {
            return new GetTournamentListResponse()
            {
                Tournaments = new List<GetTournamentResponse>()
                              {
                    new GetTournamentResponse()
                    {
                        HasBeenCancelled = ModelFactoryTestData.TournamentHasBeenCancelled,
                        HasBeenCompleted = ModelFactoryTestData.TournamentHasBeenCompleted,
                        HasResultBeenProduced = ModelFactoryTestData.HasResultBeenProduced,
                        MeasuredCourseId = ModelFactoryTestData.MeasuredCourseId,
                        MeasuredCourseName = ModelFactoryTestData.MeasuredCourseName,
                        MeasuredCourseSSS = ModelFactoryTestData.MeasuredCourseSSS,
                        MeasuredCourseTeeColour = ModelFactoryTestData.MeasuredCourseTeeColour,
                        PlayerCategory = ModelFactoryTestData.PlayerCategory,
                        PlayersScoresRecordedCount = ModelFactoryTestData.PlayersScoresRecordedCount,
                        PlayersSignedUpCount = ModelFactoryTestData.PlayersSignedUpCount,
                        TournamentDate = ModelFactoryTestData.TournamentDate.Value,
                        TournamentFormat = (TournamentFormat)ModelFactoryTestData.TournamentFormat,
                        TournamentId = ModelFactoryTestData.TournamentId,
                        TournamentName = ModelFactoryTestData.TournamentName
                    }
                              }
            };
        }

        public static GetNumberOfMembersByTimePeriodReportResponse GetNumberOfMembersByTimePeriodReportResponse()
        {
            return new GetNumberOfMembersByTimePeriodReportResponse
                   {
                        GolfClubId = ModelFactoryTestData.GolfClubId,
                        TimePeriod = TimePeriod.Year,
                        MembersByTimePeriodResponse = new List<MembersByTimePeriodResponse>
                                                      {
                                                          new MembersByTimePeriodResponse()
                                                          {
                                                              NumberOfMembers = 15,
                                                              Period = "2018"
                                                          },
                                                          new MembersByTimePeriodResponse()
                                                          {
                                                              NumberOfMembers = 25,
                                                              Period = "2019"
                                                          }
                                                      }
                   };
        }

        public static GetNumberOfMembersByAgeCategoryReportResponse GetNumberOfMembersByAgeCategoryReportResponse()
        {
            return new GetNumberOfMembersByAgeCategoryReportResponse
                   {
                GolfClubId = ModelFactoryTestData.GolfClubId,
                MembersByAgeCategoryResponse = new List<MembersByAgeCategoryResponse>
                                               {
                                                   new MembersByAgeCategoryResponse
                                                   {
                                                       AgeCategory = "Junior",
                                                       NumberOfMembers = 5
                                                   },
                                                   new MembersByAgeCategoryResponse
                                                   {
                                                       AgeCategory = "Adult",
                                                       NumberOfMembers = 35
                                                   }
                                               }
                   };
        }

        public static GetNumberOfMembersReportResponse GetNumberOfMembersReportResponse()
        {
            return new GetNumberOfMembersReportResponse
                   {
                       GolfClubId = ModelFactoryTestData.GolfClubId,
                       NumberOfMembers = 55
                   };
        }
    }
}