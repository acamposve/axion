import { createRouter, createWebHistory } from 'vue-router';
import AdminLogin from '@/components/AdminLogin.vue';
import AdminDashboard from '@/components/AdminDashboard.vue';
import CategoryList from '@/components/CategoryList.vue';
import CategoryNew from '@/components/CategoryNew.vue';
import CategoryEdit from '@/components/CategoryEdit.vue';
import ProductList from '@/components/ProductList.vue';
import ProductNew from '@/components/ProductNew.vue';
import ProductEdit from '@/components/ProductEdit.vue';

const routes = [
  { path: '/', redirect: '/admin/login' },
  { path: '/admin/login', component: AdminLogin },
  { path: '/dashboard', component: AdminDashboard },
  { path: '/categories', component: CategoryList },
  { path: '/categories/new', component: CategoryNew },  // Nueva ruta para crear categoría
  { path: '/categories/:id/edit', component: CategoryEdit },
  { path: '/products', component: ProductList },
  { path: '/products/new', component: ProductNew },  // Nueva ruta para crear categoría
  { path: '/products/:id/edit', component: ProductEdit },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
