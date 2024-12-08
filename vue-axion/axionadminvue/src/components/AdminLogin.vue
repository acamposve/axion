<template>
  <div class="container mt-5">
    <div class="row justify-content-center">
      <div class="col-md-4">
        <h2 class="text-center">Admin Login</h2>
        <form @submit.prevent="login">
          <div class="mb-3">
            <label for="login" class="form-label">Login:</label>
            <input v-model="loginData.login" type="text" class="form-control" id="login" required>
          </div>
          <div class="mb-3">
            <label for="password" class="form-label">Password:</label>
            <input v-model="loginData.password" type="password" class="form-control" id="password" required>
          </div>
          <button type="submit" class="btn btn-primary w-100">Login</button>
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
      loginData: {
        login: '',
        password: ''
      }
    };
  },
  methods: {
    async login() {
      try {
        const response = await axios.post(`${process.env.VUE_APP_API_URL}/admin/login`, this.loginData);
        localStorage.setItem('adminToken', response.data.token);
        this.$router.push('/dashboard');
      } catch (error) {
        console.error('Error during login', error);
      }
    }
  }
};
</script>

<style>
/* Opcional: Agrega estilos adicionales aquí */
</style>
