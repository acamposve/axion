<template>
  <div class="container mt-5">
    <h2 class="text-center">Category List</h2>
    <div class="card">
      <div class="card-body">
        <ul class="list-group">
          <li 
            class="list-group-item d-flex justify-content-between align-items-center" 
            v-for="category in categories" 
            :key="category.id"
          >
            {{ category.name }}
            <div>
              <button class="btn btn-warning btn-sm me-2" @click="editCategory(category.id)">Edit</button>
              <button class="btn btn-danger btn-sm" @click="deleteCategory(category.id)">Delete</button>
            </div>
          </li>
        </ul>
        <div class="text-center mt-3">
          <button class="btn btn-primary" @click="createNewCategory">Add New Category</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import CategoryService from '@/services/CategoryService';

export default {
  data() {
    return {
      categories: []
    };
  },
  async created() {
    const response = await CategoryService.getAllCategories();
    this.categories = response.data;
  },
  methods: {
    createNewCategory() {
      this.$router.push('/categories/new');
    },
    editCategory(id) {
      this.$router.push(`/categories/${id}/edit`);
    },
    async deleteCategory(id) {
      await CategoryService.deleteCategory(id);
      this.categories = this.categories.filter(category => category.id !== id);
    }
  }
};
</script>

<style>
/* Opcional: Agrega estilos adicionales aquí */
</style>
