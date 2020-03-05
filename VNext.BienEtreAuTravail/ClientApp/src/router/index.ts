import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue';
import Users from '../views/Users.vue';
import Mood from '../views/Mood.vue';
import Quotes from '../views/Quotes.vue';
import SignUp from '../views/SignUp.vue';
Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home,
  },
    {
        path: '/users',
        name: 'users',
        component:Users,
      
    },
    {
      path: '/Quotes',
      name: 'quotes',
      component: () => import(/* webpackChunkName: "about" */ '../views/Quotes.vue'),
    },
    {
        path: '/Mood',
        name: 'mood',
        component: Mood,
    },
    {
      path: '/signup',
      name: 'signup',
      component: () => import(/* webpackChunkName: "about" */ '../views/SignUp.vue'),
      
  },
    {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue'),
  },
];

const router = new VueRouter({
  routes,
});

export default router;
