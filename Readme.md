# Google and Facebook Login

Asp.Net Core MVC with Google and Facebook authentication.
Content created using this video reference: https://www.youtube.com/watch?v=YSKqZcS6PLg

## Dependencies

Google: Create an App on https://console.developers.google.com/
Facebook: Create an App on https://developers.facebook.com/
NugetPackages: 
	- Microsoft.AspNetCore.Authentication.Google
	- Microsoft.AspNetCore.Authentication.Facebook

## Used Commands
Google and Facebook:
All the information was stored in user-secrets using the commands bellow (Package Manager Console):
             
1) dotnet user-secrets init --project GoogleAndFacebookLogin
2) dotnet user-secrets set "App:GoogleClientId" "Valor do Google Client Id" --project GoogleAndFacebookLogin
3) dotnet user-secrets set "App:GoogleClientSecret" "Valor do Google Client Secret" --project GoogleAndFacebookLogin
4) dotnet user-secrets set "App:FacebookClientId" "Valor do Facebook Client Id" --project GoogleAndFacebookLogin
5) dotnet user-secrets set "App:FacebookClientSecret" "Valor do Facebook Client Secret" --project GoogleAndFacebookLogin
6) dotnet user-secrets list --project GoogleAndFacebookLogin
