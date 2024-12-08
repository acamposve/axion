<template>
  <div class="container mt-5">
    <h2 class="text-center">Lista de Productos</h2>
    <div class="card">
      <div class="card-body">
        <ul class="list-group">
          <li 
            class="list-group-item d-flex justify-content-between align-items-center" 
            v-for="product in products" 
            :key="product.id"
          >
            {{ product.name }} - ${{ product.price }}
            <div>
              <button class="btn btn-warning btn-sm me-2" @click="editProduct(product.id)">Editar</button>
              <button class="btn btn-danger btn-sm" @click="deleteProduct(product.id)">Eliminar</button>
            </div>
          </li>
        </ul>
        <div class="text-center mt-3">
          <button class="btn btn-primary" @click="createNewProduct">Agregar Nuevo Producto</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ProductService from '@/services/ProductService'; // Asegúrate de tener un servicio ProductService similar a CategoryService

export default {
  data() {
    return {
      products: []
    };
  },
  async created() {
    const response = await ProductService.getAllProducts();
    this.products = response.data;
  },
  methods: {
    createNewProduct() {
      this.$router.push('/products/new'); // Ajusta esta ruta a la correcta para agregar productos
    },
    editProduct(id) {
      this.$router.push(`/products/${id}/edit`);
    },
    async deleteProduct(id) {
      await ProductService.deleteProduct(id);
      this.products = this.products.filter(product => product.id !== id);
    }
  }
};
</script>

<style>
/* Puedes agregar estilos adicionales aquí */
</style>
