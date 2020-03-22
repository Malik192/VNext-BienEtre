import { MutationTree } from 'vuex';
import { ProfileState, User } from './types';
import Token from '@/views/Mood';

export const mutations: MutationTree<ProfileState> = {
    profileLoaded(state, payload: User) {
        state.error = false;
        state.user = payload;
        
     console.log("payload",payload)
    },
    profileError(state) {
        state.error = true;
        state.user = undefined;
        
    }, 
    tokenSet(state, payload: string) {
        state.error = false;
        state.Token = payload[0];
    console.log(payload,"payload")    
     console.log("payload",payload)
    },
};