import { GetterTree } from 'vuex';
import { ProfileState } from './types';
import { RootState } from './types';
import Token from '@/views/Mood';

export const getters: GetterTree<ProfileState, RootState> = {
    userList(state): user  {
     
        const { user } = state;
     //   const firstName = (user && user.IdEmployee) || '';
       // const lastName = (user && user.Pseudo) || '';
      //  console.log("Users ",state.user)
        return state.user;
    },
    Token(state): string  {
     
        const { user } = state;
     //   const firstName = (user && user.IdEmployee) || '';
       // const lastName = (user && user.Pseudo) || '';
      //  console.log("Users ",state.user)
        return state.Token;
    }
};