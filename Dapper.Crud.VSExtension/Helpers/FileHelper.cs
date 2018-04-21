using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dapper.Crud.VSExtension.Helpers
{
    public static class FileHelper
    {
        public static void CreateBackup(string projectpath)
        {
            Logger.Logger.Log("Backup Startup.cs and Appsetings.json files");

            File.Copy(projectpath + "startup.cs", projectpath + "startup.cs.bak", true);
            File.Copy(projectpath + "appsettings.json", projectpath + "appsettings.json.bak", true);
        }

        public static void CreateSigningConfigurationsFile(string projectpath)
        {
            Logger.Logger.Log("Creating SigningConfigurations.cs file");

            if (File.Exists(projectpath + "SigningConfigurations.cs"))
            {
                Logger.Logger.Log("File already exists, ignoring");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine(@"using System.Security.Cryptography;");
            sb.AppendLine(@"using Microsoft.IdentityModel.Tokens;");
            sb.AppendLine(@"");
            sb.AppendLine(@"    public class SigningConfigurations");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        public SecurityKey Key { get; }");
            sb.AppendLine(@"        public SigningCredentials SigningCredentials { get; }");
            sb.AppendLine(@" ");
            sb.AppendLine(@"        public SigningConfigurations()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            using (var provider = new RSACryptoServiceProvider(2048))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                Key = new RsaSecurityKey(provider.ExportParameters(true));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@" ");
            sb.AppendLine(@"            SigningCredentials = new SigningCredentials(");
            sb.AppendLine(@"                Key, SecurityAlgorithms.RsaSha256Signature);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    }");

            File.WriteAllText(projectpath + "SigningConfigurations.cs", sb.ToString());
        }

        public static void CreateTokenConfigurationsFile(string projectpath)
        {
            Logger.Logger.Log("Creating TokenConfiguration.cs File");

            if (File.Exists(projectpath + "TokenConfigurations.cs"))
            {
                Logger.Logger.Log("File already exists, ignoring");
                return;
            }

            var sb = new StringBuilder();

            sb.AppendLine(@"public class TokenConfigurations");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public string Audience { get; set; }");
            sb.AppendLine(@"    public string Issuer { get; set; }");
            sb.AppendLine(@"    public int Seconds { get; set; }");
            sb.AppendLine(@"}");

            File.WriteAllText(projectpath + "TokenConfigurations.cs", sb.ToString());
        }

        public static void AddtoConfigJson(string file)
        {
            Logger.Logger.Log("Adding info to .json file");

            // Removing the First Line of file
            var lines = File.ReadAllLines(file);

            if (lines.Any(line => line.Contains("TokenConfigurations")))
            {
                // Do not change file because configuration maybe already exists
                Logger.Logger.Log("Configuration already exists, ignoring");

                return;
            }

            File.WriteAllLines(file, lines.Skip(1).ToArray());

            var currentContent = File.ReadAllText(file);

            var sb = new StringBuilder();
            sb.AppendLine(@"{");
            sb.AppendLine(@"  ""TokenConfigurations"": {");
            sb.AppendLine(@"    ""Audience"": ""ExemploAudience"",");
            sb.AppendLine(@"    ""Issuer"": ""ExemploIssuer"",");
            sb.AppendLine(@"    ""Seconds"": 120");
            sb.AppendLine(@" },");

            File.WriteAllText(file, sb + currentContent);
        }

        public static string GetJsonFile(string projectpath)
        {
            var files = Directory.GetFiles(projectpath, "appsettings.json");
            Logger.Logger.Log($"Found .json file {files.First()}");

            return files.First();
        }

        public static void AddInfotoStartup(string projectpath)
        {
            Logger.Logger.Log("Adding info to Startup.cs file");

            string fileName = projectpath + "Startup.cs";

            // Writing Usings in the beggining of File
            var sb = new StringBuilder();
            sb.AppendLine("using Microsoft.AspNetCore.Authorization;");
            sb.AppendLine("using Microsoft.AspNetCore.Authentication.JwtBearer;");

            var currentContent = File.ReadAllText(fileName);

            if (currentContent.Contains("TokenConfigurations"))
            {
                Logger.Logger.Log("Configuration already exists, ignoring");

                return;
            }

            File.WriteAllText(fileName, sb + currentContent);

            // Removing the { after ConfigureServices to add the code
            var file = new List<string>(File.ReadAllLines(fileName));

            int index = 0;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Contains("public void ConfigureServices"))
                {
                    index = i;
                    break;
                }
            }

            file.RemoveAt(index + 1);

            var lstClass = new List<string>
            {
                @"        {",
                @"            var signingConfigurations = new SigningConfigurations();",
                @"            services.AddSingleton(signingConfigurations);",
                @"",
                @"            var tokenConfigurations = new TokenConfigurations();",
                @"            new ConfigureFromConfigurationOptions<TokenConfigurations>(",
                @"                Configuration.GetSection(""TokenConfigurations""))",
                @"                    .Configure(tokenConfigurations);",
                @"            services.AddSingleton(tokenConfigurations);",
                @"",
                @"            services.AddAuthentication(authOptions =>",
                @"            {",
                @"                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;",
                @"                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;",
                @"            }).AddJwtBearer(bearerOptions =>",
                @"            {",
                @"                var paramsValidation = bearerOptions.TokenValidationParameters;",
                @"                paramsValidation.IssuerSigningKey = signingConfigurations.Key;",
                @"                paramsValidation.ValidAudience = tokenConfigurations.Audience;",
                @"                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;",
                @"",
                @"                paramsValidation.ValidateIssuerSigningKey = true;",
                @"",
                @"                paramsValidation.ValidateLifetime = true;",
                @"",
                @"                paramsValidation.ClockSkew = TimeSpan.Zero;",
                @"            });",
                @"",
                @"            services.AddAuthorization(auth =>",
                @"            {",
                @"                auth.AddPolicy(""Bearer"", new AuthorizationPolicyBuilder()",
                @"                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)",
                @"                    .RequireAuthenticatedUser().Build());",
                @"            });"
            };

            index++;

            for (int i = 0; i < lstClass.Count; i++)
            {
                file.Insert(index + i, lstClass[i]);
            }

            File.WriteAllLines(fileName, file);
        }

        public static void CreateTokenController(string projectpath)
        {
            Logger.Logger.Log("Creating TokenController");

            if (File.Exists(projectpath + "Controllers\\TokenController.cs"))
            {
                Logger.Logger.Log("File already exists, ignoring");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
            sb.AppendLine(@"using Microsoft.AspNetCore.Authorization;");
            sb.AppendLine(@"using System.IdentityModel.Tokens.Jwt;");
            sb.AppendLine(@"using System.Security.Claims;");
            sb.AppendLine(@"using System.Security.Principal;");
            sb.AppendLine(@"using Microsoft.IdentityModel.Tokens;");
            sb.AppendLine(@"");
            sb.AppendLine(@"// This is a Token Example controller to generate the token to your API");
            sb.AppendLine(@"// To access use for ex Postman and call: http://localhost:{port}/api/token/auth");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace WebApplication5.Controllers");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    [Produces(""application/json"")]");
            sb.AppendLine(@"    [Route(""api/Token"")]");
            sb.AppendLine(@"    public class TokenController : Controller");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        [AllowAnonymous]");
            sb.AppendLine(@"        [HttpPost]");
            sb.AppendLine(@"        [Route(""auth"")]");
            sb.AppendLine(@"        public object Post(");
            sb.AppendLine(@"             [FromServices]SigningConfigurations signingConfigurations,");
            sb.AppendLine(@"             [FromServices]TokenConfigurations tokenConfigurations)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string userId = ""userId"";");
            sb.AppendLine(@"");
            sb.AppendLine(@"            ClaimsIdentity identity = new ClaimsIdentity(");
            sb.AppendLine(@"                       new GenericIdentity(userId, ""Login""),");
            sb.AppendLine(@"                       new[] {");
            sb.AppendLine(@"                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(""N"")),");
            sb.AppendLine(@"                        new Claim(JwtRegisteredClaimNames.UniqueName, userId)");
            sb.AppendLine(@"                       }");
            sb.AppendLine(@"                   );");
            sb.AppendLine(@"");
            sb.AppendLine(@"            DateTime dtCreation = DateTime.Now;");
            sb.AppendLine(@"            DateTime dtExpiration = dtCreation +");
            sb.AppendLine(@"                TimeSpan.FromSeconds(tokenConfigurations.Seconds);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            var handler = new JwtSecurityTokenHandler();");
            sb.AppendLine(@"            var securityToken = handler.CreateToken(new SecurityTokenDescriptor");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                Issuer = tokenConfigurations.Issuer,");
            sb.AppendLine(@"                Audience = tokenConfigurations.Audience,");
            sb.AppendLine(@"                SigningCredentials = signingConfigurations.SigningCredentials,");
            sb.AppendLine(@"                Subject = identity,");
            sb.AppendLine(@"                NotBefore = dtCreation,");
            sb.AppendLine(@"                Expires = dtExpiration");
            sb.AppendLine(@"            });");
            sb.AppendLine(@"            var token = handler.WriteToken(securityToken);");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return new");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                authenticated = true,");
            sb.AppendLine(@"                created = dtCreation.ToString(""yyyy - MM - dd HH: mm:ss""),");
            sb.AppendLine(@"                expiration = dtExpiration.ToString(""yyyy - MM - dd HH: mm:ss""),");
            sb.AppendLine(@"                accessToken = token,");
            sb.AppendLine(@"                message = ""OK""");
            sb.AppendLine(@"            };");
            sb.AppendLine(@"");
            sb.AppendLine(@"            // case of fail:");
            sb.AppendLine(@"            //return new");
            sb.AppendLine(@"            //{");
            sb.AppendLine(@"            //    authenticated = false,");
            sb.AppendLine(@"            //    message = ""Fail to authenticate""");
            sb.AppendLine(@"            //};");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            File.WriteAllText(projectpath + "Controllers\\TokenController.cs", sb.ToString());
        }
    }
}