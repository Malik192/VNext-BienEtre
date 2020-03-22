
/* tslint:disable */
import Vue from "vue";
import Router from "vue-router";
import Snackbar from "../components/Snackbar.vue";

import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { ProfileState, User } from '../store/profile/types';
const namespace: string = 'profile';
@Component
export  class Token extends Vue {
    @State('profile')   profile!: ProfileState;
    @Action('SetToken', { namespace }) SetToken: any;
    @Getter('token', { namespace }) token!: string;
    async AddToken(x: string){
      //   console.log("je suis la",x )
   /*  await    this.$store

         .dispatch(this.SetToken,  x)*/
    await   this.SetToken(x)
       // return this.token ;
    };
    

 
   }

export default Vue.extend({
  data: () => ({
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
    },
    
  }),
  components: {
    Snackbar
  },
  methods: {
      
  async   Authentification() {
        var p = new Token(); 
        p.AddToken(this.login)
       },
  }
});
/* tslint:disable */
