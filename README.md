# MicroServicesDotNet
MicroServices using .NET 8.0 and a set of tools.

# MAC Docker execution

1. Add into Docker "Configuration > Resources > File Sharing > Shared Files":
 * ~/.microsoft/usersecrets
 * ~/.aspnet/https
 
1.1 If necessary add the same path but using your username:
	* ~/Users/your_username/.microsoft/usersecrets
    * ~/Users/your_username/.aspnet/https

2. Sometimes Docker requires to perform "docker login" in order to execute custom API projects.

3. Install dotnet certificates on Terminal by executing: 
	* dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p pass
	* dotnet dev-certs https --trust

4. Add into Docker compose file, environment section:
	- ASPNETCORE_Kestrel__Certificates__Default__Password=pass
	- ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx