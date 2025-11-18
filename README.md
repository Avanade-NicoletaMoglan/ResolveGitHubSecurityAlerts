# Contoso Order Processor - Training Lab Project

## ⚠️ Educational Use Only

This project is intended for educational purposes only. The codebase contains intentional security vulnerabilities in the form of exposed secrets (API keys, connection strings, etc.). The code files in this project should **NOT** be used in production environments and aren't designed to model production code.

This project is designed for a course that teaches how to identify and resolve security vulnerabilities (exposed secrets) using GitHub Copilot and GitHub Security features. Other than the intentional code vulnerabilities, the codebase is designed to follow coding best practices.

## Overview

ContosoOrderProcessor simulates an order processing application. This project supports the following developer security topics:

- Using GitHub Secret Scanning to identify exposed secrets.
- Using GitHub Copilot to resolve security alerts.
- Implementing secure configuration management practices.
- Applying security best practices in .NET applications.

## Application Features

The application simulates a complete e-commerce order processing workflow including:

- **Customer Management**: Customer data retrieval and validation.
- **Order Processing**: Order creation, validation, and tracking.
- **Payment Processing**: Integration with Stripe and PayPal payment gateways.
- **Email Notifications**: Order confirmation and shipping notifications via SendGrid and SMTP.
- **Security Validation**: Input validation, fraud detection, and security checks.
- **Database Operations**: Order persistence and transaction logging.
- **Cloud Integration**: AWS and Azure cloud service configurations.

## Project Structure

``` plaintext
ContosoOrderProcessor/
├── Configuration/
│   └── AppConfig.cs              # Application configuration (contains exposed secrets)
├── Models/
│   ├── Customer.cs               # Customer entity model
│   └── Order.cs                  # Order and OrderItem models
├── Security/
│   └── SecurityValidator.cs      # Security validation and fraud detection
├── Services/
│   ├── DatabaseService.cs        # Database operations (contains exposed secrets)
│   ├── EmailService.cs           # Email notifications (contains exposed secrets)
│   └── PaymentService.cs         # Payment processing (contains exposed secrets)
└── Program.cs                    # Main application entry point
```

## Intentional Security Vulnerabilities

The application contains the following **intentional** security issues for training purposes:

### Exposed Secrets

**Currently Exposed in Source Code:**

- ❌ Hard-coded Stripe API keys (PaymentService.cs)
- ❌ Hard-coded Square Access Token (PaymentService.cs)
- ❌ Hard-coded Mailgun API key (EmailService.cs)
- ❌ Hard-coded SMTP credentials (EmailService.cs)
- ❌ Hard-coded Twilio credentials (AppConfig.cs)
- ❌ Hard-coded Slack Bot Token (AppConfig.cs)
- ❌ Hard-coded Slack Incoming Webhook URL (AppConfig.cs)
- ❌ Hard-coded JWT secret keys (AppConfig.cs)
- ❌ Hard-coded encryption keys (AppConfig.cs)

**Already Refactored to Environment Variables:**

- ✓ AWS credentials (Access Key ID and Secret Access Key)
- ✓ SendGrid API key
- ✓ PayPal credentials (Client ID and Secret)
- ✓ SQL Server connection string
- ✓ GitHub Personal Access Token
- ✓ npm Token
- ✓ Azure Storage Connection String

The remaining exposed secrets should be detected by GitHub Secret Scanning and resolved using secure configuration management practices.

## Prerequisites

- .NET 9.0 SDK or later
- Visual Studio Code or Visual Studio 2022
- GitHub account with Secret Scanning enabled
- GitHub Copilot subscription (for AI-assisted remediation)

## Running the Application

### Set environment variables and run the application

You need to set up environment variables before running the application.

The following commands can be used to set environment variables and run the application:

```powershell
$env:Aws__AccessKeyId = "AKIA1234567890EXAMPLE"
$env:Aws__SecretAccessKey = "1234567890abcdefghijklmnopqrstuvwxyzABCD"
$env:SendGrid__ApiKey = "SG.1234567890abcdefghij.1234567890abcdefghijklmnopqrstuvwxyzABCDEF"
$env:PayPal__ClientId = "AY1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmno"
$env:PayPal__ClientSecret = "EJ1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklm"
$env:Database__ConnectionString = "Server=tcp:contoso-orders.database.windows.net,1433;Initial Catalog=ContosoOrdersDB;User ID=orderadmin;Password=MyPassword123!;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=False;Connection Timeout=30;"
$env:GitHub__PersonalAccessToken = "ghp_1234567890abcdefghijklmnopqrstuvwxyzAB"
$env:Npm__Token = "npm_1234567890abcdefghijklmnopqrstuvwxy"

cd ContosoOrderProcessor
dotnet run
```

**Note**: Environment variables must use double underscores (`__`) to represent hierarchy in .NET configuration. All secret values are **fictional** and created for training purposes only.

### Using Azure Key Vault to replace environment variables

**Important**: For production environments, Azure Key Vault provides a secure alternative to environment variables stored in plain text files or configuration.

This application is configured to work with Azure Key Vault for production deployments.

Quick overview of Azure Key Vault setup:

1. **Create Key Vault**: `az keyvault create --name contoso-vault --resource-group myRG --location eastus`
2. **Store secrets**: `az keyvault secret set --vault-name contoso-vault --name 'Aws-AccessKeyId' --value 'YOUR_KEY'`
3. **Add NuGet packages**: Azure.Extensions.AspNetCore.Configuration.Secrets, Azure.Identity
4. **Update Program.cs**: Add `AddAzureKeyVault()` to ConfigurationBuilder

Benefits: Encryption at rest/transit, automatic rotation, audit logging, RBAC, Managed Identity integration, HSM backing.

### Expected Output

The application produces verifiable console output showing a complete order processing workflow:

``` plaintext
╔════════════════════════════════════════════════════════╗
║   Contoso Order Processor - E-Commerce Application     ║
╚════════════════════════════════════════════════════════╝

=== Application Configuration ===
Application: Contoso Order Processor v2.1.0
Environment: Production
...

╔════════════════════════════════════════════════════════╗
║              ORDER PROCESSING COMPLETED                ║
╚════════════════════════════════════════════════════════╝

✓ Order ID: ORD-20251113202904
✓ Customer: Lee Gu (lee.gu@example.com)
✓ Total Amount: $148.94
✓ Payment Method: Stripe
✓ Status: Shipped
✓ Transaction ID: TXN-20251113202904-7782143D
✓ Tracking Number: TRK-EEC64BA1
```

## Additional Resources

- [EXPOSED_SECRETS_REFERENCE.md](./EXPOSED_SECRETS_REFERENCE.md) - Detailed list of intentional vulnerabilities
- [GitHub Secret Scanning Documentation](https://docs.github.com/en/code-security/secret-scanning)
- [.NET Configuration Best Practices](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Azure Key Vault for .NET](https://learn.microsoft.com/en-us/azure/key-vault/)

## Notes

- All credentials in this codebase are **fictional** and created for training purposes only
- The application uses simulated external service calls (no real API calls are made)
- Database operations are simulated and do not require an actual database
- This code should never be deployed to production environments

## License

See [LICENSE-CODE](./LICENSE-CODE) for licensing information.

## Security Policy

See [SECURITY.md](./SECURITY.md) for our security policy (part of the training exercise).
