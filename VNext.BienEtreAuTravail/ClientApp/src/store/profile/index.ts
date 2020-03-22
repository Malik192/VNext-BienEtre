import { Module } from 'vuex';
import { getters } from './Getters';
import { actions } from './actions';
import { mutations } from './Mutations';
import { ProfileState } from './types';
import { RootState } from './types';

export const state: ProfileState = {
    user: undefined,
    Token: "",

    error: false
};


const namespaced: boolean = true;

export const profile: Module<ProfileState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations
};