import { ActionTree } from 'vuex';
import axios from 'axios';
import { ProfileState } from './types';
import { User } from "../types/User";
import { RootState } from './types';

import VueCookies from "vue-cookies";
import Mood from '@/views/Mood';
import Quote from '@/views/Quotes';
/**
 * @description:actions est l'un des trois composants de vuex state management pattern (State,Mutation,Action)
 * actions permet d'executer des fonction asynchrones dans ce cas des appels a l'api
 * 
 */

export const actions: ActionTree<ProfileState, RootState> = {


  /**
   * @method: GetUsers
   * @description: get users from controller and commit the list to mutation.
   */
  async GetUsers({ commit }): Promise<void> {
    let url: string = `https://localhost:44380/api/User`;

    let errors: string = ``;
    await axios
      .get(url)
      .then(response => {
        const payload = response && response.data;
        commit('profileLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
      })
      .catch(e => {
        errors;
      });
  },
  /**
   * 
   * @description: get quotes from controller and commit the list to mutation
   * @
   */

  async GetQuotes({ commit }): Promise<void> {
    let url: string = `https://localhost:44310/api/Quotes`;

    let errors: string = ``;
    await axios
      .get(url)
      .then(response => {
        const payload = response && response.data;
        commit('QuotesLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
      })
      .catch(e => {
        errors;
      });
  },
  /**
   * @method: UpdateUsers
   *@param: value : contains formData from users.ts
   */
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
  /**
  * @method: AddQuote
  *@param: value : contains formData from Quotes.ts
  @description: call quotes api with post request and commit the response as an array to mutation
  */
  async AddQuote({ commit }, value: any): Promise<any> {
    let url: string = `https://localhost:44310/api/Quotes`;

    let errors: string = ``;
    await axios
      .post(url, {
        Auteur: value.Auteur,
        Citation: value.Citation,
        Famille_de_mot: value.Famille_de_mot,
        Groupe: value.Groupe,

      })
      .then(response => {
        const payload: User = response && response.data;
        /**
         * call QuotesLoaded method in mutations.ts with payload as param    
        */
        commit('QuotesLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
        //  this.dispatch("Users",posts) 
      })
      .catch(e => {
        errors;
      });
  },

  /**
   * @method: DeleteUsers
   *@param: user  
   */
  async DeleteUsers({ commit }, user: User): Promise<any> {
    let url: string = `https://localhost:44380/api/User/${user.IdEmployee}`;

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

  /**
  * @method: DeleteQuote
  *@param: quote  
  */

  async DeleteQuote({ commit }, quote: Quote): Promise<any> {
    console.log("quote ", quote)
    let url: string = `https://localhost:44310/api/Quotes/${quote.ID}`;

    let errors: string = ``;
    await axios
      .delete(url)
      .then(response => {
        const payload: Quote = response && response.data;
        commit('QuotesLoaded', payload);
      }, (error) => {
        console.log(error);
        commit('profileError');
      })
      .catch(e => {
        errors;
      });
  },
  /**
   * @method: SetToken
   * @param: payload
   * @description: get token from server side and set isconnected to true
  */
  async SetToken({ commit }, payload: any): Promise<any> {
    let url: string = `https://localhost:44380/api/Auths`;
    let errors: string = ``;
    let IsAdmin = false;
    await axios
      .post(url, {
        Pseudo: payload.login,
        Password: payload.password
      })
      .then(response => {
        var cookie = response.data[0];
        let Isconected = false;
        if (payload.login == "admin") {
          IsAdmin = true
        }
        if (cookie) {
          Isconected = true
        }

        const formData = {
          Pseudo: payload.login,
          IsAdmin: IsAdmin,
          IsConnected: Isconected

        };


        commit('userPseudo', formData);



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
        commit('logoutUser');
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