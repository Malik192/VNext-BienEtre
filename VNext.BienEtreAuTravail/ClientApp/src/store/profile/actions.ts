import { ActionTree } from 'vuex';
import axios from 'axios';
import { ProfileState, User } from './types';
import { RootState } from './types';
import Token from '@/views/Mood';


export const actions: ActionTree<ProfileState, RootState> = {
    async GetUsers({ commit }): Promise<any> {
        let url: string = `https://localhost:44380/api/User`;
        console.log("error");
        let errors: string = ``;
     await   axios
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
        
        /*
        then((response) => {
            const payload: User = response && response.data;
            commit('profileLoaded', payload);
        }, (error) => {
            console.log(error);
            commit('profileError');
        });
    }
    */
 
}, 
async SetToken({ commit },x: string): Promise<any> {
  let url: string = `https://localhost:44380/api/Auths`;
  console.log("error");
  let errors: string = ``;
await axios
.post(url, {
  Pseudo: x,
  Password:'malik'
})
.then(response => {
  console.log("je suis la",response.data[0])
  var payload =response.data[0];
 
  commit('tokenSet', payload);
 
}, (error) => {
  console.log(error);
  commit('profileError');
//  this.dispatch("Users",posts) 
})
.catch(e => {
  errors;
});
  
  /*
  then((response) => {
      const payload: User = response && response.data;
      commit('profileLoaded', payload);
  }, (error) => {
      console.log(error);
      commit('profileError');
  });
}
*/

},

}