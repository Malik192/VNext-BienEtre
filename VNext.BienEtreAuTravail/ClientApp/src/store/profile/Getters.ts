import { GetterTree } from 'vuex';
import { ProfileState } from './types';
import { Quotes } from "../types/Quote";
import { RootState } from './types';
import Token from '@/views/Mood';

export const getters: GetterTree<ProfileState, RootState> = {
  userList(state): any { 
    return state.user;
  },

  userValue(state): any { 
      return state.Pseudo;
    },
  
  quotesList(state): any {  
    return state.quotes;
  },
  TokenValue(state): boolean { 
    const { user } = state; 
    return state.IsConnected;
  },
  IsAdmin(state): boolean { 
    const { user } = state; 
    return state.IsAdmin;
  }
};