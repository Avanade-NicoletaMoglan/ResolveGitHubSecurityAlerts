# Exposed Secrets Reference - Contoso Order Processor

This document provides a reference for the intentional security vulnerabilities included in the ContosoOrderProcessor application for training purposes.

## Purpose

This application demonstrates common security issues that can be detected by GitHub Secret Scanning. The exposed secrets are intentional and should be identified and remediated as part of the training lab.

## Exposed Secrets by File

### 1. Services/PaymentService.cs

- **Type**: Payment API Keys
- **Issue**: Hard-coded Stripe and Square API credentials
- **Lines**: 24, 27
- **Value Types**:
  - Stripe Live API Key (sk_live_*)
  - Square Access Token (EAAA*)
- **Severity**: Critical
- **Status**: ✓ PayPal credentials refactored to environment variables

### 2. Services/EmailService.cs

- **Type**: Email Service Credentials
- **Issue**: Hard-coded Mailgun API key and SMTP credentials
- **Lines**: 19, 22-24
- **Value Types**:
  - Mailgun API Key (key-*)
  - SMTP server credentials
- **Severity**: High
- **Status**: ✓ SendGrid API key refactored to environment variables

### 3. Configuration/AppConfig.cs

- **Type**: Multiple Service Credentials and Keys
- **Issue**: Hard-coded credentials for various services
- **Lines**: 37-60
- **Value Types**:
  - Twilio Account SID and Auth Token
  - Slack Bot Token (xoxb-*)
  - Slack Incoming Webhook URL (hooks.slack.com/services/*)
  - Azure Storage Connection String
  - JWT Secret Key
  - Encryption Key and IV
- **Severity**: High to Medium
- **Status**: ✓ AWS credentials refactored to environment variables
- **Status**: ✓ GitHub PAT refactored to environment variables
- **Status**: ✓ npm Token refactored to environment variables
- **Status**: ✓ Azure Storage connection string refactored to environment variables

## Refactored Secrets (Now Using Environment Variables)

### Previously Exposed, Now Secured

1. **AWS Credentials** - Access Key ID and Secret Access Key (AppConfig.cs)
2. **SendGrid API Key** - Email service authentication (EmailService.cs)
3. **PayPal Credentials** - Client ID and Secret (PaymentService.cs)
4. **SQL Server Connection String** - Database credentials (DatabaseService.cs)
5. **GitHub Personal Access Token** - Repository access (AppConfig.cs)
6. **npm Token** - Package registry access (AppConfig.cs)
7. **Azure Storage Connection String** - Storage account credentials (AppConfig.cs)

## Expected Detections

GitHub Secret Scanning should detect the following patterns:

### Currently Exposed (Should Be Detected)

1. ✓ Stripe API keys (live keys) - PaymentService.cs
2. ✓ Square Access Token - PaymentService.cs
3. ✓ Mailgun API key - EmailService.cs
4. ✓ Slack Bot Token - AppConfig.cs
5. ✓ Slack Incoming Webhook URL - AppConfig.cs

### May Be Detected by GitHub

1. ✓ Twilio credentials - AppConfig.cs

### Not Detected by GitHub (Generic Patterns)

- SMTP passwords (too generic)
- JWT secret keys (not service-specific)
- Encryption keys (application-specific)

### The following Secrets are managed via environment variables (should not be detected)

1. ✗ AWS credentials
2. ✗ SendGrid API key
3. ✗ PayPal credentials
4. ✗ SQL Server connection string
5. ✗ GitHub Personal Access Token
6. ✗ npm Token
7. ✗ Azure Storage connection string
