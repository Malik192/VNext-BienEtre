import { ActionTree } from 'vuex';
import axios from 'axios';
import { ProfileState } from './types';
import { User } from "../types/User";
import { RootState } from './types';

import VueCookies from "vue-cookies";
import Token from '@/views/Mood';
import Quote from '@/views/Quotes';


export const actions: ActionTree<ProfileState, RootState> = {
  async GetUsers({ commit }): Promise<any> {
    let url: string = `https://localhost:44380/api/User`;
    console.log("error");
    let errors: string = ``;
    await axios
      .get(url)
      .then(response => {
        const payload: User = response && response.data;
        commit('profileLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },

  async GetQuotes({ commit }): Promise<any> {
    let url: string = `https://localhost:44310/api/Quotes`;
    console.log("error");
    let errors: string = ``;
    await axios
      .get(url)
      .then(response => {
        const payload: Quote = response && response.data;
        commit('Quotes', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },

  async UpdateUsers({ commit }, value: any): Promise<any> {
    let url: string = `https://localhost:44380/api/User/${value.IdEmployee}`;

    let errors: string = ``;
    await axios
      .put(url, {
        IdEmployee: value.IdEmployee,
        Pseudo: value.Pseudo,
        Password: value.Password
      })
      .then(response => {
        const payload: User = response && response.data;
        commit('profileLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },
  async AddQuote({ commit }, value: any): Promise<any> {
    let url: string = `https://localhost:44310/api/Quotes`;

    let errors: string = ``;
    await axios
      .post(url, {
        Auteur: value.Auteur,
        Citation: value.Citation,
        Famille_de_mot:value.Famille_de_mot,
        Groupe: value.Groupe,
    
      })
      .then(response => {
        const payload: User = response && response.data;
        commit('Quotes', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },
  

  async DeleteUsers({ commit }, value: any): Promise<any> {
    let url: string = `https://localhost:44380/api/User/${value.IdEmployee}`;

    let errors: string = ``;
    await axios
      .delete(url)
      .then(response => {
        const payload: User = response && response.data;
        commit('profileLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },
  async DeleteQuote({ commit }, value: any): Promise<any> {
    let url: string = `https://localhost:44310/api/Quotes/${value.ID}`;

    let errors: string = ``;
    await axios
      .delete(url)
      .then(response => {
        console.log('success')
        const payload: Quote = response && response.data;
        commit('Quotes', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },
  async SetToken({ commit }, payload: any): Promise<any> {
    let url: string = `https://localhost:44380/api/Auths`;
    let errors: string = ``;
    await axios
      .post(url, {
        Pseudo: payload.login,
        Password: payload.password
      })
      .then(response => {

        var cookie = response.data[0];

        commit('userPseudo', payload.login);

        commit('tokenSet', cookie);


      }, (error) => {

        commit('profileError');
      })
      .catch(e => {
        errors;
      });



  },

  async LogoutUser({ commit }): Promise<any> {
    let url: string = `https://localhost:44380/api/SignOut`;
    let errors: string = ``;
    await axios
      .post(url)
      .then(response => {
        const payload: User = response && response.data;
        commit('logoutUser', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },

}