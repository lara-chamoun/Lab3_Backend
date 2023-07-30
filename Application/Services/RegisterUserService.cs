using System.Text;
using System.Text.Json;
using Application.IServices;
using Application.Models;
using Domain.Entities;
using Persistence;

namespace Application.Services;

public class RegisterUserService : IRegisterUserService
{

    private readonly HttpClient _httpClient;

    private readonly PostgresContext _postgresContext;

    public RegisterUserService(HttpClient httpClient, PostgresContext postgresContext)
    {
        _httpClient = httpClient;
        _postgresContext = postgresContext;

    }

  
    public async Task<User> RegisterUser(string name, string email, string password , int role_id)
    {
        try
        {

            var createUserEndpoint = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyC5H-ZTvnSj7IAgWtzd7Z0MB6Egzzr6x98";

            var content = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(createUserEndpoint, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Content: {responseContent}"); // Add this line to check the response content

                var jsonResponse = JsonSerializer.Deserialize<SignUpResponse>(responseContent);

                // Save the user token to your application's database or session
                string userToken = jsonResponse.idToken;

                // Optionally, you can also save the user's unique Firebase user ID (UID)
                string firebaseUserId = jsonResponse.localId;

                // Handle the response or do other actions if needed
                
                var req = new User {  Name = name, RoleId= role_id, FireBaseId = firebaseUserId, Email = email};
                _postgresContext.Add(req);
                _postgresContext.SaveChanges();
                //return Ok(new { Token = userToken, UserId = firebaseUserId });
            }
            else
            {
                // Handle error response
                var errorContent = await response.Content.ReadAsStringAsync();
               // return BadRequest($"Error creating user: {errorContent}");
            }
        }
        catch (Exception ex)
        {
            // Handle other errors
          //  return BadRequest($"Error creating user: {ex.Message}");
        }


        return null;
    }
}