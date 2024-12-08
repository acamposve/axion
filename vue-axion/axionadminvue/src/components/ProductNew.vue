<template>
  <div class="container mt-5">
    <h2 class="text-center">Crear Nuevo Producto</h2>
    <div class="card">
      <div class="card-body">
        <form @submit.prevent="createProduct">
          <div class="mb-3">
            <label for="name" class="form-label">Nombre:</label>
            <input 
              v-model="name" 
              type="text" 
              id="name" 
              class="form-control" 
              required 
              placeholder="Ingresa el nombre del producto"
            >
          </div>
          <div class="mb-3">
            <label for="description" class="form-label">Descripción:</label>
            <textarea 
              v-model="description" 
              id="description" 
              class="form-control" 
              required 
              placeholder="Ingresa una descripción"
            ></textarea>
          </div>
          <div class="mb-3">
            <label for="categoryId" class="form-label">Categoría:</label>
            <select 
              v-model="categoryId" 
              id="categoryId" 
              class="form-select" 
              required
            >
              <option value="" disabled>Selecciona una categoría</option>
              <option v-for="category in categories" :key="category.id" :value="category.id">
                {{ category.name }}
              </option>
            </select>
          </div>
          <div class="mb-3">
            <label for="price" class="form-label">Precio:</label>
            <input 
              v-model="price" 
              type="number" 
              id="price" 
              class="form-control" 
              required 
              placeholder="Ingresa el precio del producto"
            >
          </div>
          <div class="mb-3">
            <label for="isFeatured" class="form-label">Destacado:</label>
            <input 
              type="checkbox" 
              v-model="isFeatured" 
              id="isFeatured"
            >
          </div>
          <div class="mb-3">
            <label for="image" class="form-label">Imagen:</label>
            <input 
              @change="onFileChange" 
              type="file" 
              id="image" 
              class="form-control" 
              accept="image/*"
            >
          </div>
          <div class="text-center">
            <button type="submit" class="btn btn-primary">Crear Producto</button>
            <button type="button" class="btn btn-secondary ms-3" @click="$router.push('/products')">Cancelar</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      name: '',
      description: '',
      categoryId: '',
      price: '',
      isFeatured: false,
      image: null,
      categories: [] // Agregar el array para las categorías
    };
  },
  methods: {
    onFileChange(e) {
      this.image = e.target.files[0];
    },
    async createProduct() {
      const formData = new FormData();
      formData.append('name', this.name);
      formData.append('description', this.description);
      formData.append('categoryId', this.categoryId);
      formData.append('price', this.price);
      formData.append('isFeatured', this.isFeatured);
      formData.append('image', this.image);

      try {
        await axios.post(`${process.env.VUE_APP_API_URL}/products/create`, formData, {
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        });
        this.$router.push('/products');
      } catch (error) {
        console.error('Error creando el producto:', error);
        alert('Hubo un error al crear el producto. Inténtalo de nuevo.');
      }

      // Limpiar el formulario
      this.name = '';
      this.description = '';
      this.categoryId = '';
      this.price = '';
      this.isFeatured = false;
      this.image = null;
    },
    async fetchCategories() {
      try {
        const response = await axios.get(`${process.env.VUE_APP_API_URL}/categories/all`);
        this.categories = response.data; // Asigna la respuesta a categories
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
    }
  },
  mounted() {
    this.fetchCategories(); // Llama a fetchCategories al montar el componente
  }
};
</script>

<style>
/* Opcional: puedes añadir estilos adicionales aquí si es necesario */
</style>
