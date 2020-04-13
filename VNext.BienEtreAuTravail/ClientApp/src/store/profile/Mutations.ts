import { MutationTree } from 'vuex';
import { ProfileState } from './types';
import { Quotes } from "../types/Quote";
import { User } from "../types/User";

export const mutations: MutationTree<ProfileState> = {
    profileLoaded(state, payload: User) {
        state.error = false;
        state.user = payload;
         
    },
    QuotesLoaded(state, payload: Quotes) {
        state.error = false;
        state.quotes = payload;
         
    },
    logoutUser(state) {
        state.error = false;
        state.IsConnected = false;
        state.Pseudo="";
        state.quotes=undefined;
        state.user=undefined;
         
    },
    profileError(state) {
        state.error = true;
        state.user = undefined;
        
    }, 
   
    userPseudo(state, payload) {
        state.error = false;
        state.Pseudo = payload.Pseudo;
        state.IsAdmin=payload.IsAdmin;      
        state.IsConnected=payload.IsConnected;
    },
};