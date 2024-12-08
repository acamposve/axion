<template>
  <div class="container mt-5">
    <h2 class="text-center">Editar Categoría</h2>
    <div class="card">
      <div class="card-body">
        <form @submit.prevent="updateCategory">
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
            <label>Imagen Actual:</label>
            <div class="mt-2">
              <img 
                v-if="image" 
                :src="image" 
                alt="Imagen Actual" 
                class="img-thumbnail" 
                style="width: 150px; height: auto;"
              >
            </div>
          </div>
          <div class="mb-3">
            <label for="image" class="form-label">Cambiar Imagen:</label>
            <input 
              @change="onFileChange" 
              type="file" 
              id="image" 
              class="form-control" 
              accept="image/*"
            >
          </div>
          <div class="text-center">
            <button type="submit" class="btn btn-primary">Actualizar Categoría</button>
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
      image: null,
      newImage: null
    };
  },
  methods: {
    async fetchCategory() {
      try {
        const response = await axios.get(`${process.env.VUE_APP_API_URL}/categories/${this.$route.params.id}`);
        this.name = response.data.name;
        this.description = response.data.description;
        this.image = `${process.env.VUE_APP_IMAGE_URL}${response.data.image}`;
      } catch (error) {
        console.error('Error fetching category:', error);
        alert('Error al cargar la categoría. Inténtalo de nuevo.');
      }
    },
    onFileChange(e) {
      this.newImage = e.target.files[0];
    },
    async updateCategory() {
      const formData = new FormData();
      formData.append('name', this.name);
      formData.append('description', this.description);
      if (this.newImage) {
        formData.append('image', this.newImage);
      }

      try {
        await axios.put(`${process.env.VUE_APP_API_URL}/categories/${this.$route.params.id}`, formData, {
          headers: {
            'Content-Type': 'multipart/form-data'
          }
        });
        this.$router.push('/categories');
      } catch (error) {
        console.error('Error updating category:', error);
        alert('Error al actualizar la categoría. Inténtalo de nuevo.');
      }
    }
  },
  mounted() {
    this.fetchCategory();
  }
};
</script>

<style>
/* Puedes agregar estilos adicionales aquí si es necesario */
</style>
