<template>
    <div class="container mt-5">
      <h2 class="text-center">Editar Producto</h2>
      <div class="card">
        <div class="card-body">
          <form @submit.prevent="updateProduct">
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
              <label for="categoryId" class="form-label">Categoría ID:</label>
              <input 
                v-model="categoryId" 
                type="number" 
                id="categoryId" 
                class="form-control" 
                required 
                placeholder="Ingresa el ID de la categoría"
              >
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
              <button type="submit" class="btn btn-primary">Actualizar Producto</button>
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
        newImage: null
      };
    },
    methods: {
      async fetchProduct() {
        try {
          const response = await axios.get(`${process.env.VUE_APP_API_URL}/products/${this.$route.params.id}`);
          const product = response.data;
          this.name = product.name;
          this.description = product.description;
          this.categoryId = product.categoryId;
          this.price = product.price;
          this.isFeatured = product.isFeatured;
          //this.image = product.image; // URL de la imagen
          this.image = `${process.env.VUE_APP_IMAGE_URL}${product.image}`;

        } catch (error) {
          console.error('Error al obtener el producto:', error);
          alert('Hubo un error al cargar el producto. Inténtalo de nuevo.');
        }
      },
      onFileChange(e) {
        this.newImage = e.target.files[0];
      },
      async updateProduct() {
        const formData = new FormData();
        formData.append('name', this.name);
        formData.append('description', this.description);
        formData.append('categoryId', this.categoryId);
        formData.append('price', this.price);
        formData.append('isFeatured', this.isFeatured);
        if (this.newImage) {
          formData.append('image', this.newImage);
        }
  
        try {
          await axios.put(`${process.env.VUE_APP_API_URL}/products/${this.$route.params.id}`, formData, {
            headers: {
              'Content-Type': 'multipart/form-data'
            }
          });
          this.$router.push('/products');
        } catch (error) {
          console.error('Error actualizando el producto:', error);
          alert('Hubo un error al actualizar el producto. Inténtalo de nuevo.');
        }
      }
    },
    created() {
      this.fetchProduct();
    }
  };
  </script>
  
  <style>
  /* Opcional: puedes añadir estilos adicionales aquí si es necesario */
  </style>
  