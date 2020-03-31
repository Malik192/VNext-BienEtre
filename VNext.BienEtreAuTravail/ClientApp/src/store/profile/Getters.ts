import { GetterTree } from 'vuex';
import { ProfileState } from './types';
import { Quotes } from "../types/Quotes";
import { RootState } from './types';
import Token from '@/views/Mood';

export const getters: GetterTree<ProfileState, RootState> = {
  userList(state): any {

  //  const { user } = state;

    return state.user;
  },

  userValue(state): any {

    //  const { user } = state;
  
      return state.Pseudo;
    },
  
  quotesList(state): any {

  //  const { quotes } = state;

    return state.quotes;
  },
  TokenValue(state): boolean {

    const { user } = state;

    return state.IsConnected;
  }
};