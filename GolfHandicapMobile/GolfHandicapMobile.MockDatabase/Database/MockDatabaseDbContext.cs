using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandicapMobile.MockAPI.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HandicapMobile.MockAPI.Database
{
    using GolfHandicapMobile.MockDatabase.Database.Models;

    public class MockDatabaseDbContext : DbContext
    {
        private readonly String ConnectionString;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDatabaseDbContext"/> class.
        /// </summary>
        public MockDatabaseDbContext()
        {
            // Use this for migrations
            this.ConnectionString = "server=localhost;database=MockDatabase;user id=root;password=Pa55word";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDatabaseDbContext" /> class using the connection string passed in.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public MockDatabaseDbContext(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDatabaseDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MockDatabaseDbContext(DbContextOptions<MockDatabaseDbContext> options) : base(options)
        {
        }

        #endregion

        #region protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)        
        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!String.IsNullOrWhiteSpace(this.ConnectionString))
            {
                optionsBuilder.UseMySql(this.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        #region Entities

        /// <summary>
        /// Gets or sets the registered users.
        /// </summary>
        /// <value>
        /// The registered users.
        /// </value>
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public DbSet<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the golf clubs.
        /// </summary>
        /// <value>
        /// The golf clubs.
        /// </value>
        public DbSet<GolfClub> GolfClubs { get; set; }

        /// <summary>
        /// Gets or sets the golf club memberships.
        /// </summary>
        /// <value>
        /// The golf club memberships.
        /// </value>
        public DbSet<GolfClubMembership> GolfClubMemberships { get; set; }

        #endregion
    }
}
