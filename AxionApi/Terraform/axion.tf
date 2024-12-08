# Crear el grupo de recursos en Brazil South
resource "azurerm_resource_group" "main" {
  name     = "myResourceGroup"
  location = "Brazil South"
}

# Crear un grupo de contenedores para la API .NET
resource "azurerm_container_group" "dotnet_api" {
  name                = "dotnet-api-container"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  os_type             = "Linux"

  container {
    name   = "dotnet-api"
    image  = "my-dotnet-api-image:latest"  # Cambia esto a la imagen que necesitas
    cpu    = "1"  # Número de CPUs asignadas
    memory = "1.5"  # Memoria en GB asignada

    ports {
      port     = 80
      protocol = "TCP"
    }

    environment_variables = {
      "ASPNETCORE_ENVIRONMENT" = "Production"
    }
  }

  tags = {
    environment = "production"
  }
}

# Crear un grupo de contenedores para la aplicación Vue.js
resource "azurerm_container_group" "vue_app" {
  name                = "vue-app-container"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  os_type             = "Linux"

  container {
    name   = "vue-app"
    image  = "my-vue-app-image:latest"  # Cambia esto a la imagen que necesitas
    cpu    = "1"  # Número de CPUs asignadas
    memory = "1.5"  # Memoria en GB asignada

    ports {
      port     = 80
      protocol = "TCP"
    }

    environment_variables = {
      "NODE_ENV" = "production"
    }
  }

  tags = {
    environment = "production"
  }
}
