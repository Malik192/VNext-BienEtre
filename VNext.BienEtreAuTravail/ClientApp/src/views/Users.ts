import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { ProfileState, User } from '../store/profile/types';
const namespace: string = 'profile';
@Component
export default class UserDetail extends Vue {
    @State('profile')   profile!: ProfileState;
    @Action('GetUsers', { namespace }) GetAllUsers: any;
 //   @Action('SetToken', { namespace }) SetToken: any;
    @Getter('userList', { namespace }) user!: Array<User>[];
    data() {
      return {
        id: 0,
     
        errors: [],
        
        login: "",
        password: "",
        componentKey: 0, 
      
        dialog: false,
        show1: false,
        rules: {
          required: (value: any) => !!value || "Champ requis.",
          min: (v: string | any[]) => v.length >= 5 || "Min 5 characters"
        },
        text: "",
  
        snackbar: false
      };
    }
    posts: Array<User>[] = [];
    IdEmployee: number= 0 
    async mounted() {
      
        // fetching data as soon as the component's been mounted
        //this.posts=this.$store.state,
   
      await  this.GetAllUsers();
    //  this.SetToken("malik")
      this.posts=this.user
    }

 
   }