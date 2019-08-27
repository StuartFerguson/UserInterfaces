namespace GolfClubAdminWebSite.IntegrationTests.Common
{
    using System;
    using MySql.Data.MySqlClient;

    public static class SecurityServiceHelper
    {
        public static Int32 GetClientId(MySqlConnection connection,
                                        String clientId)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT Id FROM Clients WHERE ClientId = '{clientId}'";
            Object result = command.ExecuteScalar();

            if (result != null)
            {
                return Convert.ToInt32(result);
            }

            return -1;
        }

        public static void UpdateClientRedirectUri(MySqlConnection connection,
                                                   Int32 clientIdentifier,
                                                   String redirectUri)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM ClientRedirectUris WHERE ClientId = {clientIdentifier}; " +
                                  $"INSERT INTO ClientRedirectUris(RedirectUri, ClientId) SELECT '{redirectUri}', {clientIdentifier}";
            command.ExecuteNonQuery();
        }

        public static void UpdateClientPostLogoutRedirectUri(MySqlConnection connection,
                                                             Int32 clientIdentifier,
                                                             String postLogoutRedirectUri)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM ClientPostLogoutRedirectUris WHERE ClientId = {clientIdentifier}; " +
                                  $"INSERT INTO ClientPostLogoutRedirectUris(PostLogoutRedirectUri, ClientId) SELECT '{postLogoutRedirectUri}', {clientIdentifier}";
            command.ExecuteNonQuery();
        }

        public static void DeleteAllUsers(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM AspNetUsers;";
            command.ExecuteNonQuery();
        }
    }
}