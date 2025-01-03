namespace EcommerceProject.Shared.Dtos;

public record PayerRequest(string UserId, string Name, string Surname, string Email, 
    string Type, string NumberId, string StreetName, 
    string StreetNumber, string ZipCode, string AreaCode, string PhoneNumber 
);

