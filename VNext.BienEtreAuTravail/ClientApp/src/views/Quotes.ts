import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';
import Component from 'vue-class-component';
import { Watch } from 'vue-property-decorator'
import { ProfileState } from '../store/profile/types';
import { User } from "../store/types/User";
import QuoteDialog from "@/components/QuoteDialog.vue";

const namespace: string = 'profile';
 
@Component
export default class Quote extends Vue {
    
    @State('profile')   profile!: ProfileState;
     
  
    @Action('AddQuote', { namespace }) Add: any;
    @Getter('quotesList', { namespace }) Getquotes!: Array<Quote>[];

  
  @Action('DeleteQuote', { namespace }) Delete: any;

    data() {
      return {
        Famille_de_mot:"",  
        items: ["MOI AVEC ENTREPRISE", "MOI AVEC MOI MEME", "MOI AU TRAVAIL", "MOI CHEZ LE CLIENT"],
        groupe:"",
        Auteur:'',
        Citation:"",
        dialog: false,
        Edit: false,
        posts:[],
        quote:[],
        max: 140,
        text: "",
        componentKey: 0,
        snackbar: false
      };
    };
    @Watch('componentKey', { immediate: true, deep: true })
  onPropertyChanged() {
    this.$data.posts = this.Getquotes
  }

    async mounted() {
      this.$data.posts = this.Getquotes
  
    };
    openDialog(value: number) {
        console.log(value)
        this.$data.quote = value;
      }
    async  deleteQuotes(value: any, i: number) {
        console.log(value)
        await this.Delete(value)
        this.$data.componentKey++;
        this.$data.text = "citation supprimée";
        this.$data.snackbar = true;
      }
 async saveQuote(value: any) {
    const formData = {
    Auteur: this.$data.Auteur,
    Citation: this.$data.Citation,
Famille_de_mot:this.$data.Famille_de_mot,
      Groupe: this.$data.groupe,

    };
    await this.Add(formData);
    this.$data.dialog = false;
    this.$data.componentKey++;
    this.$data.text = "Modification enregistrée ";
    this.$data.snackbar = true;

   }
};
