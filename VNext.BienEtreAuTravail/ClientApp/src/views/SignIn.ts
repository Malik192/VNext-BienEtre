
/* tslint:disable */
import Vue from "vue";
import Router from "vue-router";
import Snackbar from "../components/Snackbar.vue";

import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { Watch } from 'vue-property-decorator'
import { ProfileState } from '../store/profile/types';
import { User } from "../store/types/User";
const namespace: string = 'profile';
@Component
export default class SignIN extends Vue {
  @State('profile') profile!: ProfileState;
  @Action('SetToken', { namespace }) SetToken: any;
  @Getter('TokenValue', { namespace }) Isconnected!: boolean;
  
  @Getter('IsAdmin', { namespace }) IsAdmin!: boolean;
  @Getter('userValue', { namespace }) username!: string;
  data() {
    return {
      login: "",
      password: "",
      cook: "",
      cookieName: "Vnext",
      show1: false,
      text: "",
      snackbar: false,
      rules: {
        required: (value: any) => !!value || "Champ requis.",
        min: (v: string | any[]) => v.length >= 5 || "Min 5 characters"
      }

    };
  }

  @Watch('$route', { immediate: true, deep: true })
  onPropertyChanged() {

    this.$data.text = this.$route.params.text;
    this.$data.snackbar = this.$route.params.snackbar;

  }
  async Authentification(login: string, password: string) {
    const formData = {

      login: login,

      password: password

    };
    await this.SetToken(formData)

    if (this.Isconnected != false) {

      if (this.IsAdmin) {
        this.$router.push({ name: 'admin', params: { text: "Bienvenue dans la partie administrateur Mood@work!", snackbar: 'true' } })
      }

      else{

        this.$router.push({ name: 'mood', params: { text: "Bienvenue a toi dans Mood@work!", snackbar: 'true' } })

      }
    }
    else
      this.$router.push('/')
  };



}
