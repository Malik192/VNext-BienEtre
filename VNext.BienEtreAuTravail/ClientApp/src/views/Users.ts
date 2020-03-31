import Vue from 'vue';
import { State, Action, Getter } from 'vuex-class';

//import Component from 'vue-class-component';
import { Component, Watch } from 'vue-property-decorator'
import axios from 'axios';
import { ProfileState } from '../store/profile/types';
import { User } from "../store/types/User";
const namespace: string = 'profile';

@Component
export default class UserDetail extends Vue {

  @State('profile') profile!: ProfileState;
  @Action('GetUsers', { namespace }) Get: any;
  @Action('UpdateUsers', { namespace }) Update: any;
  @Action('DeleteUsers', { namespace }) Delete: any;
  @Action('SetToken', { namespace }) SetToken: any;
  @Getter('userList', { namespace }) Getusers!: Array<User>[];


  data() {
    return {
      id: 0,

      errors: [],

      login: "",
      password: "",
      posts: [],
      update: [],
      componentKey: 0,
      url: `https://localhost:44380/api/User`,
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
  @Watch('$route', { immediate: true, deep: true })
  onPropertyChangedSnackbar() {

    this.$data.text=this.$route.params.text;
    this.$data.snackbar=this.$route.params.snackbar;

  }
  async mounted() {
    await this.Get();
    this.$data.posts = this.Getusers

  };

  openDialog(value: any) {
    this.$data.id = value.IdEmployee;
  }
  @Watch('componentKey', { immediate: true, deep: true })
  onPropertyChanged() {
    this.$data.posts = this.Getusers
  }
  async saveUser(value: any) {
    const formData = {
      id: value.IdEmployee,
      IdEmployee: this.$data.id,
      Pseudo: this.$data.login,
      Password: this.$data.password

    };
    await this.Update(formData)
    this.$data.dialog = false;
    this.$data.componentKey++;

    this.$data.text = "Modification enregistrée ";
    this.$data.snackbar = true;
  };
  async  deleteUser(value: any, i: number) {
    await this.Delete(value)
    this.$data.componentKey++;
    this.$data.text = "Utilisateur " + value.Pseudo + " supprimé";
    this.$data.snackbar = true;
  }
}