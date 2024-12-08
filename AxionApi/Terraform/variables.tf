variable "ARM_CLIENT_ID" {
  description = "El Client ID de la aplicación de Azure"
  type        = string
}

variable "ARM_CLIENT_SECRET" {
  description = "El Client Secret de la aplicación de Azure"
  type        = string
}

variable "ARM_SUBSCRIPTION_ID" {
  description = "El Subscription ID de la cuenta de Azure"
  type        = string
}

variable "ARM_TENANT_ID" {
  description = "El Tenant ID de la cuenta de Azure"
  type        = string
}

variable "sql_admin_password" {
  description = "Password for the SQL admin user"
  type        = string
}