import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { Watch } from 'vue-property-decorator'
import { ProfileState } from '../store/profile/types';
import { User } from "../store/types/User";
import Quote from './Quotes';
const namespace: string = 'profile';
@Component
export default class Token extends Vue {
    @State('profile')   profile!: ProfileState;
    
  @Action('GetQuotes', { namespace }) Get: any;
  
  @Getter('quotesList', { namespace }) Getquotes!: Array<Quote>[];
    data() {
      return {
        login: "", 
        password: "",
        componentKey: 0, 
        dialog: false,
        show1: false,
        text: "",
        snackbar:false
      };
    };
    async mounted() {
      await this.Get(); 
  
    };
    @Watch('$route', { immediate: true, deep: true })
  onPropertyChangedSnackbar() :void {
    this.$data.text=this.$route.params.text;
    this.$data.snackbar=this.$route.params.snackbar;


  }


   }