import axios from 'axios';

const apiURL = process.env.VUE_APP_API_URL;

export default {
  getAllProducts() {
    return axios.get(`${apiURL}/products/all`);
  },
  getProduct(id) {
    return axios.get(`${apiURL}/products/${id}`);
  },
  createProduct(product) {
    return axios.post(`${apiURL}/products`, product);
  },
  updateProduct(id, product) {
    return axios.put(`${apiURL}/products/${id}`, product);
  },
  deleteProduct(id) {
    return axios.delete(`${apiURL}/products/${id}`);
  }
};
