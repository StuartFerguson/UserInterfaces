namespace GolfClubAdminWebSite.Factories
{
    using System.Collections.Generic;
    using Areas.Account.Models;
    using Areas.GolfClubAdministrator.Models;
    using ManagementAPI.Service.DataTransferObjects;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GolfClubAdminWebSite.Factories.IModelFactory" />
    public class ModelFactory : IModelFactory
    {
        #region Methods

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public RegisterClubAdministratorRequest ConvertFrom(RegisterClubAdministratorViewModel viewModel)
        {
            RegisterClubAdministratorRequest registerRegisterClubAdministratorRequest = new RegisterClubAdministratorRequest
                                                                                        {
                                                                                            ConfirmPassword = viewModel.ConfirmPassword,
                                                                                            EmailAddress = viewModel.Email,
                                                                                            Password = viewModel.Password,
                                                                                            TelephoneNumber = viewModel.TelephoneNumber
                                                                                        };

            return registerRegisterClubAdministratorRequest;
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public CreateGolfClubRequest ConvertFrom(CreateGolfClubViewModel viewModel)
        {
            CreateGolfClubRequest createGolfClubRequest = new CreateGolfClubRequest
                                                          {
                                                              AddressLine1 = viewModel.AddressLine1,
                                                              Region = viewModel.Region,
                                                              Town = viewModel.Town,
                                                              Website = viewModel.Website,
                                                              Name = viewModel.Name,
                                                              TelephoneNumber = viewModel.TelephoneNumber,
                                                              EmailAddress = viewModel.EmailAddress,
                                                              AddressLine2 = viewModel.AddressLine2,
                                                              PostalCode = viewModel.PostalCode,
                                                              TournamentDivisions = new List<TournamentDivision>()
                                                          };

            return createGolfClubRequest;
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="apiResponse">The API response.</param>
        /// <returns></returns>
        public UpdateGolfClubViewModel ConvertFrom(GetGolfClubResponse apiResponse)
        {
            UpdateGolfClubViewModel viewModel = new UpdateGolfClubViewModel
                                                {
                                                    Region = apiResponse.Region,
                                                    Town = apiResponse.Town,
                                                    Website = apiResponse.Website,
                                                    EmailAddress = apiResponse.EmailAddress,
                                                    Name = apiResponse.Name,
                                                    TelephoneNumber = apiResponse.TelephoneNumber,
                                                    AddressLine1 = apiResponse.AddressLine1,
                                                    AddressLine2 = apiResponse.AddressLine2,
                                                    PostalCode = apiResponse.PostalCode,
                                                    Id = apiResponse.Id
                                                };

            return viewModel;
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public AddMeasuredCourseToClubRequest ConvertFrom(MeasuredCourseViewModel viewModel)
        {
            AddMeasuredCourseToClubRequest request = new AddMeasuredCourseToClubRequest
                                                     {
                                                         StandardScratchScore = viewModel.StandardScratchScore,
                                                         TeeColour = viewModel.TeeColour,
                                                         Name = viewModel.Name,
                                                         Holes = new List<HoleDataTransferObject>()
                                                     };

            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 1, LengthInYards = viewModel.HoleNumber1Yards, Par = viewModel.HoleNumber1Par, StrokeIndex = viewModel.HoleNumber1StrokeIndex});
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 2, LengthInYards = viewModel.HoleNumber2Yards, Par = viewModel.HoleNumber2Par, StrokeIndex = viewModel.HoleNumber2StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 3, LengthInYards = viewModel.HoleNumber3Yards, Par = viewModel.HoleNumber3Par, StrokeIndex = viewModel.HoleNumber3StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 4, LengthInYards = viewModel.HoleNumber4Yards, Par = viewModel.HoleNumber4Par, StrokeIndex = viewModel.HoleNumber4StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 5, LengthInYards = viewModel.HoleNumber5Yards, Par = viewModel.HoleNumber5Par, StrokeIndex = viewModel.HoleNumber5StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 6, LengthInYards = viewModel.HoleNumber6Yards, Par = viewModel.HoleNumber6Par, StrokeIndex = viewModel.HoleNumber6StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 7, LengthInYards = viewModel.HoleNumber7Yards, Par = viewModel.HoleNumber7Par, StrokeIndex = viewModel.HoleNumber7StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 8, LengthInYards = viewModel.HoleNumber8Yards, Par = viewModel.HoleNumber8Par, StrokeIndex = viewModel.HoleNumber8StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 9, LengthInYards = viewModel.HoleNumber9Yards, Par = viewModel.HoleNumber9Par, StrokeIndex = viewModel.HoleNumber9StrokeIndex });

            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 10, LengthInYards = viewModel.HoleNumber10Yards, Par = viewModel.HoleNumber10Par, StrokeIndex = viewModel.HoleNumber10StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 11, LengthInYards = viewModel.HoleNumber11Yards, Par = viewModel.HoleNumber11Par, StrokeIndex = viewModel.HoleNumber11StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 12, LengthInYards = viewModel.HoleNumber12Yards, Par = viewModel.HoleNumber12Par, StrokeIndex = viewModel.HoleNumber12StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 13, LengthInYards = viewModel.HoleNumber13Yards, Par = viewModel.HoleNumber13Par, StrokeIndex = viewModel.HoleNumber13StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 14, LengthInYards = viewModel.HoleNumber14Yards, Par = viewModel.HoleNumber14Par, StrokeIndex = viewModel.HoleNumber14StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 15, LengthInYards = viewModel.HoleNumber15Yards, Par = viewModel.HoleNumber15Par, StrokeIndex = viewModel.HoleNumber15StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 16, LengthInYards = viewModel.HoleNumber16Yards, Par = viewModel.HoleNumber16Par, StrokeIndex = viewModel.HoleNumber16StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 17, LengthInYards = viewModel.HoleNumber17Yards, Par = viewModel.HoleNumber17Par, StrokeIndex = viewModel.HoleNumber17StrokeIndex });
            request.Holes.Add(new HoleDataTransferObject { HoleNumber = 18, LengthInYards = viewModel.HoleNumber18Yards, Par = viewModel.HoleNumber18Par, StrokeIndex = viewModel.HoleNumber18StrokeIndex });

            return request;
        }

        #endregion
    }
}