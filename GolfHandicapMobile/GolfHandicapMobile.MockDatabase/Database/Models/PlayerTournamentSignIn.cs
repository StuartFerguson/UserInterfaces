using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.MockDatabase.Database.Models
{
    public class PlayerTournamentSignIn
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the tournament identifier.
        /// </summary>
        /// <value>
        /// The tournament identifier.
        /// </value>
        public Guid TournamentId { get; set; }
    }
}
