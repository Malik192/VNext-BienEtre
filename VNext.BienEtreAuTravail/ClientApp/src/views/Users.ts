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
  //watcher le changement de route et prendre les infos pour la snackbar ...
  @Watch('$route', { immediate: true, deep: true })
  onPropertyChangedSnackbar() {

    this.$data.text = this.$route.params.text;
    this.$data.snackbar = this.$route.params.snackbar;

  }
  /**
   * @description:   watcher le changement d'une variable pour rafraichir le contenu ...
   */
  @Watch('componentKey', { immediate: true, deep: true })
  onPropertyChanged() {
    this.$data.posts = this.Getusers
  }
  /**
   * @description:(mounted): methode executée au montage de l'instance vue sur le dom
   * Get appel la methode Get users dans action(Vuex)
   */

  async mounted() {

    await this.Get();
    this.$data.posts = this.Getusers

  };
  /**
   * @description: recuperation de l'id avant la modification de l'utilisateur
   * @param value 
   */

  openDialog(value: number) {
    this.$data.id = value;
  }

  /**
   * 
   * @param value 
   */
  async saveUser(value: User) {
    const formData = {
      id: value.IdEmployee,
      IdEmployee: this.$data.id,
      Pseudo: this.$data.login,
      Password: this.$data.password

    };
    var state = "modifié"
    await this.Update(formData)
    this.$data.dialog = false;
    this.routine(formData.Pseudo, state);


  };

  /**
   * @description: appel la methode deleteUser users dans action(Vuex) ligne 17
   * @param user 
   */
  public async  deleteUser(user: User): Promise<void> {
    var state = "supprimé"
    await this.Delete(user)
    this.routine(user.Pseudo, state);

  }
  /**
   * @description: methode routiniere qui incremente la valriable observée et permet l'affichage de la snackbar
   * @param pseudo 
   * @param state 
   */
  public routine(pseudo: string, state: string): void {
    this.$data.componentKey++;
    this.$data.snackbar = true;
    this.$data.text = "Utilisateur " + pseudo + " " + state;

  }
}