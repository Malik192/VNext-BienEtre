import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import { Component, Watch } from 'vue-property-decorator'
import { ProfileState } from '../store/profile/types';
import { User } from "../store/types/User";
import router from '@/router';
const namespace: string = 'profile';
@Component
export default class Navbar extends Vue {

  @State('profile') profile!: ProfileState;
  @Action('LogoutUser', { namespace }) Logout: any;
  @Getter('TokenValue', { namespace }) TokenValue!: boolean;


  data() {
    return {
      cook: "",
      cookieName: "Vnext",
      text: "",
      snackbar: false
    };
  }
  get Isconnected() {
    return this.TokenValue;
  }
  async logout() {
    await this.Logout();
    router.push({ name: 'home', params: { text: "Tu es déconnecté !", snackbar:'true' } })
  
  };

}