import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { ProfileState, User } from '../store/profile/types';
const namespace: string = 'profile';
@Component
export default class Token extends Vue {
    @State('profile')   profile!: ProfileState;
    @Action('SetToken', { namespace }) SetToken: any;
    @Getter('token', { namespace }) token!: string;
    data() {
      return {
        login: "",
        password: "",
        componentKey: 0, 
        dialog: false,
        show1: false,
        text: "",
      };
    }
    //posts: Array<User>[] = [];
  
    async setTocken(response :any) {
        // fetching data as soon as the component's been mounted
      
      await  this.SetToken(response);
     }

 
   }