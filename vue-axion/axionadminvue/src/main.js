import { createApp } from 'vue';
import App from './App.vue';
import router from './router'; // Importa el router
import 'bootstrap/dist/css/bootstrap.css'; // Importa Bootstrap CSS
createApp(App)
  .use(router)  // Usa el router
  .mount('#app');
