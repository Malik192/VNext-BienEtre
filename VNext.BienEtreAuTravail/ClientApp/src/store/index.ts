import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';
import { RootState } from './profile/types';
import { profile, state } from './profile/index';
import { getters } from './profile/Getters';

Vue.use(Vuex);

const store: StoreOptions<RootState> = {
    state: {
        version: '1.0.0', 
    },
    modules: {
        profile
    },
    getters: {
        version: state => state.version,
      }
};
export default new Vuex.Store<RootState>(store);
