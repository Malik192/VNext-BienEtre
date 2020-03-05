import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios'
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {



    login ({ commit }, data) {

      axios.post('http://localhost:4000' + '/api/login', {



        login: data.login,



        password: data.password,

        userid: this.getters.userVal



      }).then((response) => {

        console.log('user number', response)

        if (response.data.statusCode === 200) {

          console.log('status 1', response.data.statusCode)

          commit('userAuth', {

            token: response.data.token,

            userId: response.data.userid,

            userName: response.data.username,

            status: response.data.statusCode

          })

        } else {

          console.log('status 2', response.data.statusCode)

          commit('userStatus', {

            status: response.data.statusCode

          })

        }

        // eslint-disable-next-line no-unused-expressions

      })

    },
  },
  modules: {
  },
});
