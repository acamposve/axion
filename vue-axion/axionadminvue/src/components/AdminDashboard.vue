<template>
  <div>
    <h1>Admin Dashboard</h1>
    <p>Bienvenido, Admin!</p>
    <router-link to="/categories">Ir a Categorías</router-link> |
    <router-link to="/products">Ir a Productos</router-link>
  </div>
</template>

<script>
export default {
  name: 'AdminDashboard',  // Cambia el nombre del componente aquí
};
</script>
