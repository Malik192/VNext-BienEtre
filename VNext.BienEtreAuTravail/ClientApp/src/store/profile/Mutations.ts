import { MutationTree } from 'vuex';
import { ProfileState } from './types';
import { Quotes } from "../types/Quotes";
import { User } from "../types/User";

export const mutations: MutationTree<ProfileState> = {
    profileLoaded(state, payload: User) {
        state.error = false;
        state.user = payload;
         
    },
    Quotes(state, payload: Quotes) {
        state.error = false;
        state.quotes = payload;
         
    },
    logoutUser(state, payload: User) {
        state.error = false;
        state.IsConnected = false;
        state.Pseudo="";
         
    },
    profileError(state) {
        state.error = true;
        state.user = undefined;
        
    }, 
    tokenSet(state, payload: string) { 
        if (payload) {
            state.error = false;
            state.IsConnected =true;
         
        }
       else  {

        state.error = false;
        state.IsConnected = false;
 
       }
    },
    userPseudo(state, payload: string) {
        state.error = false;
        state.Pseudo = payload;

    },
};