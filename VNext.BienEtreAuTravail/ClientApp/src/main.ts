import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './registerServiceWorker'
import vuetify from './plugins/vuetify'

import VueCookies from 'vue-cookies'
import { state } from './store/profile'
Vue.use(VueCookies)



Vue.config.productionTip = true;



router.beforeEach((to, from, next) => {
  if (to.name != 'home' && to.name != 'signup' && state.IsConnected==false) next({ name: 'home' })
  else 
  next()
})

new Vue({
  el: '#app',
  router,
  store,
vuetify,
  render: (h) => h(App),
}).$mount('#app');
