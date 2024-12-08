<template>
  <div class="container mt-5">
    <h2 class="text-center">Crear Nueva Categoría</h2>
    <div class="card">
      <div class="card-body">
        <form @submit.prevent="createCategory">
          <div class="mb-3">
            <label for="name" class="form-label">Nombre:</label>
            <input 
              v-model="name" 
              type="text" 
              id="name" 
              class="form-control" 
              required 
              placeholder="Ingresa el nombre de la categoría"
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
            <button type="submit" class="btn btn-primary">Crear Categoría</button>
            <button type="button" class="btn btn-secondary ms-3" @click="$router.push('/categories')">Cancelar</button>
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
      image: null
    };
  },
  methods: {
    onFileChange(e) {
      this.image = e.target.files[0];
    },
    async createCategory() {
      const formData = new FormData();
      formData.append('name', this.name);
      formData.append('description', this.description);
      formData.append('image', this.image);

      try {
        await axios.post(`${process.env.VUE_APP_API_URL}/Categories/create`, formData, {
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        });
        this.$router.push('/categories');
      } catch (error) {
        console.error('Error creando la categoría:', error);
        alert('Hubo un error al crear la categoría. Inténtalo de nuevo.');
      }

      // Limpiar el formulario
      this.name = '';
      this.description = '';
      this.image = null;
    }
  }
};
</script>

<style>
/* Opcional: puedes añadir estilos adicionales aquí si es necesario */
</style>
