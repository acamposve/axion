import axios from 'axios';

const apiURL = process.env.VUE_APP_API_URL;

export default {
  getAllCategories() {
    return axios.get(`${apiURL}/categories/all`);
  },
  getCategory(id) {
    return axios.get(`${apiURL}/categories/${id}`);
  },
  createCategory(category) {
    return axios.post(`${apiURL}/categories/create`, category);
  },
  updateCategory(id, category) {
    return axios.put(`${apiURL}/categories/${id}`, category);
  },
  deleteCategory(id) {
    return axios.delete(`${apiURL}/categories/${id}`);
  }
};
